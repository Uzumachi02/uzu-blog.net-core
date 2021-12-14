CREATE TABLE IF NOT EXISTS "public"."languages" (
	"id" serial4,
	"culture_name" varchar NOT NULL,
	"display_name" varchar NOT NULL,
	"country" varchar NOT NULL,
	"region" varchar NOT NULL,
	"icon" varchar NOT NULL,
	"display_order" int4 DEFAULT 0,
	"is_default" bool DEFAULT false,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
