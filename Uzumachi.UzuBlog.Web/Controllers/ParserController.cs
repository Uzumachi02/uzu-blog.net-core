﻿using Microsoft.AspNetCore.Mvc;
using Uzumachi.UzuBlog.Data.Interfaces;
using Uzumachi.UzuBlog.Domain.Types;
using Uzumachi.UzuBlog.Web.Parsers;

namespace Uzumachi.UzuBlog.Web.Controllers;

public class ParserController : ControllerBase {

  private readonly ILogger<ParserController> _logger;

  private readonly IUnitOfWork _unitOfWork;

  public ParserController(ILogger<ParserController> logger, IUnitOfWork unitOfWork) {
    _logger = logger;
    _unitOfWork = unitOfWork;
  }

  public async Task<IActionResult> PointMd(CancellationToken cancellationToken) {
    var parser = new PoindMdParser();
    var result = await parser.Run(cancellationToken);

    if( result?.errors is not null ) {
      Ok(result.errors);
    }

    var response = new ResponseParser();
    var languageId = 1;

    foreach( var item in result.data.contents ) {
      cancellationToken.ThrowIfCancellationRequested();

      if( item.cparent is null ) {
        continue;
      }

      var transaction = _unitOfWork.BeginTransaction();
      try {
        var dbPost = await _unitOfWork.Posts.GetByAliasAsync(item.url);

        if( dbPost != null ) {
          response.IncrementExists();
          transaction.Dispose();

          _logger.LogInformation($"Post exists by alias: {item.url}");
          continue;
        }

        var dbCategory = await _unitOfWork.Categories.GetByAliasAsync(item.cparent.url.ru);

        if( dbCategory is null ) {
          dbCategory = new() {
            Alias = item.cparent.url.ru,
            Title = item.cparent.title.ru,
            LanguageId = languageId,
            ItemTypeId = ItemTypes.Post
          };

          await _unitOfWork.Categories.CreateAsync(dbCategory, cancellationToken, transaction);
        }

        dbPost = new() {
          UserId = 1,
          LanguageId = 1,
          Alias = item.url,
          Title = item.title.@long,
          CategoryId = dbCategory.Id,
          Excerpt = item.description.intro,
          Content = item.description.@long
        };

        await _unitOfWork.Posts.CreateAsync(dbPost, cancellationToken, transaction);
        response.IncrementAdded();

        transaction.Commit();
      } catch( Exception ex) {
        transaction.Rollback();

        _logger.LogError(ex, "");
      } finally {
        transaction.Dispose();
      }
    }

    return Ok(response);
  }

  private record ResponseParser() {

    public int Added { get; set; }

    public int Exists { get; set; }

    public void IncrementAdded() {
      Added++;
    }

    public void IncrementExists() {
      Exists++;
    }
  }
}
