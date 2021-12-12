CREATE TABLE IF NOT EXISTS "public"."posts" (
	"id" serial4,
	"user_id" int4 NOT NULL,
	"category_id" int4 NOT NULL,
	"language_id" int4 NOT NULL,
	"image_id" int4,
	"alias" varchar NOT NULL,
	"title" varchar NOT NULL,
	"excerpt" varchar NOT NULL,
	"content" varchar NOT NULL,
	"image" varchar,
	"tag_count" int4 DEFAULT 0,
	"view_count" int4 DEFAULT 0,
	"like_count" int4 DEFAULT 0,
	"comment_count" int4 DEFAULT 0,
	"close_comments" bool DEFAULT false,
	"status" int4 DEFAULT 0,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"publish_date" timestamp,
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id"),
	UNIQUE ("alias")
);

CREATE INDEX ON "public"."posts" USING hash (
	"alias"
);