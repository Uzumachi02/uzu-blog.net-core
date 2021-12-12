CREATE TABLE IF NOT EXISTS "public"."language_resources" (
	"id" serial4,
	"language_id" int4 NOT NULL,
	"key" varchar NOT NULL,
	"value" varchar NOT NULL,
	"comment" varchar,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
