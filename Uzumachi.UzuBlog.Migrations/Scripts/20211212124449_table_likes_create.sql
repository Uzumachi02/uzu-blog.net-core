CREATE TABLE IF NOT EXISTS "public"."likes" (
	"id" serial4,
	"user_id" int4 NOT NULL,
	"item_type_id" int4 NOT NULL,
	"item_id" int4 NOT NULL,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
