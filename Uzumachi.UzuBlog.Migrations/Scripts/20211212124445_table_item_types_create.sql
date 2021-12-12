CREATE TABLE IF NOT EXISTS "public"."item_types" (
	"id" serial4,
	"name" varchar NOT NULL,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
