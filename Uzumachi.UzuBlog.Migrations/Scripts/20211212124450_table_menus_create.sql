CREATE TABLE IF NOT EXISTS "public"."menus" (
	"id" serial4,
	"parent_id" int4 DEFAULT 0,
	"user_id" int4 NOT NULL,
	"menu_type_id" int4 NOT NULL,
	"language_id" int4 NOT NULL,
	"item_type_id" int4 DEFAULT 0,
	"item_id" int4 DEFAULT 0,
	"alias" varchar NOT NULL,
	"title" varchar NOT NULL,
	"url" varchar NOT NULL,
	"display_order" int4 DEFAULT 0,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
