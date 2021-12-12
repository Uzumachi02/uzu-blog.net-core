CREATE TABLE IF NOT EXISTS "public"."seo" (
	"id" serial4,
	"user_id" int4 NOT NULL,
	"item_type_id" int4,
	"item_id" int4,
	"url" varchar,
	"title" varchar,
	"h1" varchar,
	"description" varchar,
	"keywords" varchar,
	"others" varchar,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
