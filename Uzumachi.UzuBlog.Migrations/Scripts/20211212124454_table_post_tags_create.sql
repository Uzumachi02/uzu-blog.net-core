CREATE TABLE IF NOT EXISTS "public"."post_tags" (
	"id" serial4,
	"post_id" int4 NOT NULL,
	"tag_id" int4 NOT NULL,
	PRIMARY KEY ("id")
);
