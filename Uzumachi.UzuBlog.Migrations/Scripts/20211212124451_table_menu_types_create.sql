CREATE TABLE IF NOT EXISTS "public"."menu_types" (
	"id" serial4,
	"name" varchar NOT NULL,
	"create_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
