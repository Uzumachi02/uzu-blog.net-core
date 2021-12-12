CREATE TABLE IF NOT EXISTS "public"."comments" (
	"id" serial4,
	"parent_id" int4 DEFAULT 0,
	"user_id" int4 NOT NULL,
	"item_type_id" int4  NOT NULL,
	"item_id" int4 NOT NULL,
	"reply_id" int4 DEFAULT 0,
	"reply_user_id" int4 DEFAULT 0,
	"text" varchar NOT NULL,
	"like_count" int4 DEFAULT 0,
	"reply_count" int4 DEFAULT 0,
	"is_banned" bool DEFAULT false,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
