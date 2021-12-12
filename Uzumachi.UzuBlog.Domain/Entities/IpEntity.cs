namespace Uzumachi.UzuBlog.Domain.Entities;

public class IpEntity : IEntity {

  public const string TABLE = "public.ips";

  public int Id { get; set; }

  public string Ip { get; set; }

  public string CountryName { get; set; }

  public string CityName { get; set; }

  public DateTime CreateDate { get; set; }

  public DateTime UpdateDate { get; set; }
}

