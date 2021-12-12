CREATE TABLE IF NOT EXISTS "public"."language_items_connections" (
	"id" serial4,
	"language_id" int4 NOT NULL,
	"item_type_id" int4 NOT NULL,
	"base_item_id" int4 NOT NULL,
	"second_item_id" int4 NOT NULL,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
