CREATE OR REPLACE FUNCTION "public"."update_counter_in_posts_and_tags"()
  RETURNS "pg_catalog"."trigger" AS $BODY$
	DECLARE
		_post_id INTEGER;
		_tag_id INTEGER;
	BEGIN
		IF (TG_OP = 'DELETE') THEN
			_post_id = OLD.post_id;
			_tag_id = OLD.tag_id;
		ELSIF (TG_OP = 'INSERT') THEN
			_post_id = NEW.post_id;
			_tag_id = NEW.tag_id;
		END IF;
		
		UPDATE "public".posts SET tag_count = (SELECT COUNT(*) FROM "public".post_tags WHERE post_id = _post_id) WHERE id = _post_id;
		UPDATE "public".tags SET post_count = (SELECT COUNT(*) FROM "public".post_tags WHERE tag_id = _tag_id) WHERE id = _tag_id;
		
		RETURN NULL;
	END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;

CREATE TRIGGER "update_counter_in_posts_and_tags" AFTER INSERT OR DELETE ON "public"."post_tags"
FOR EACH ROW
EXECUTE PROCEDURE "public"."update_counter_in_posts_and_tags"();