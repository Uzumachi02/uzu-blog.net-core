CREATE TABLE IF NOT EXISTS "public"."pages" (
	"id" serial4,
	"user_id" int4 NOT NULL,
	"language_id" int4 NOT NULL,
	"alias" varchar NOT NULL,
	"title" varchar NOT NULL,
	"content" varchar NOT NULL,
	"view_count" int4 DEFAULT 0,
	"status" int4 DEFAULT 0,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id"),
	UNIQUE ("alias")
);

CREATE INDEX ON "public"."pages" USING hash (
	"alias"
);