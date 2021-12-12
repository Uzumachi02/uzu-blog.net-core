CREATE TABLE IF NOT EXISTS "public"."ips" (
	"id" serial4,
	"ip" varchar NOT NULL,
	"country_name" varchar,
	"city_name" varchar,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id"),
	UNIQUE ("ip")
);
