CREATE TABLE IF NOT EXISTS "public"."users" (
	"id" serial4,
	"language_id" int4,
	"username" varchar NOT NULL,
	"email" varchar NOT NULL,
	"password" varchar,
	"first_name" varchar,
	"last_name" varchar,
	"birthday" timestamp,
	"avatar" varchar,
	"is_admin" bool DEFAULT false,
	"is_banned" bool DEFAULT false,
	"is_deleted" bool DEFAULT false,
	"online_date" timestamp,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
