CREATE OR REPLACE FUNCTION "public"."update_tag_ids_in_post"()
  RETURNS "pg_catalog"."trigger" AS $BODY$
	DECLARE
		_post_id INTEGER;
	BEGIN
		IF (TG_OP = 'DELETE') THEN
			_post_id = OLD.post_id;
		ELSE
			_post_id = NEW.post_id;
		END IF;
		
		UPDATE "public".posts SET tag_ids = ARRAY(SELECT tag_id FROM "public".post_tags WHERE post_id = _post_id) WHERE id = _post_id;
		
		RETURN NULL;
	END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;

CREATE TRIGGER "update_tag_ids_in_post" AFTER INSERT OR UPDATE OR DELETE ON "public"."post_tags"
FOR EACH ROW
EXECUTE PROCEDURE "public"."update_tag_ids_in_post"();