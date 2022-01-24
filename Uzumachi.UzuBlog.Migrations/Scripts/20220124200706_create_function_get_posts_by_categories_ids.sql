CREATE OR REPLACE FUNCTION "public"."get_posts_by_categories_ids"("_categories_ids" _int4, "_limit_posts" int4=20)
  RETURNS SETOF "public"."posts" AS $BODY$
	BEGIN
		FOR i IN array_lower(_categories_ids, 1) .. array_upper(_categories_ids, 1)
		LOOP
			RETURN query SELECT * FROM posts WHERE is_deleted = false AND category_id = _categories_ids[i] LIMIT _limit_posts;
		END LOOP;
	END
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000