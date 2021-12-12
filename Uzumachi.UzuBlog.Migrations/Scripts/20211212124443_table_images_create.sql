CREATE TABLE IF NOT EXISTS "public"."images" (
	"id" serial4,
	"user_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"relative_path" varchar NOT NULL,
	"absolute_path" varchar NOT NULL,
	"hash" varchar NOT NULL,
	"width" int4,
	"height" int4,
	"size" int4,
	"status" int4 DEFAULT 0,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
