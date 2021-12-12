CREATE TABLE IF NOT EXISTS "public"."tags" (
	"id" serial4,
	"language_id" int4 NOT NULL,
	"alias" varchar NOT NULL,
	"title" varchar NOT NULL,
	"post_count" int4 DEFAULT 0,
	"status" int4 DEFAULT 0,
	"is_deleted" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id"),
	UNIQUE ("alias")
);

CREATE INDEX ON "public"."tags" USING hash (
	"alias"
);