CREATE TABLE IF NOT EXISTS "public"."categories" (
	"id" serial4,
	"parent_id" int4 DEFAULT 0,
	"language_id" int4 NOT NULL,
	"item_type_id" int4 NOT NULL,
	"alias" varchar NOT NULL,
	"title" varchar NOT NULL,
	"display_order" int4 DEFAULT 0,
	"post_count" int4 DEFAULT 0,
	"status" int4 DEFAULT 0,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id"),
	UNIQUE ("alias")
);

CREATE INDEX ON "public"."categories" USING hash (
	"alias"
);