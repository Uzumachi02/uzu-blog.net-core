CREATE TABLE IF NOT EXISTS "public"."user_agents" (
	"id" serial4,
	"user_agent" varchar NOT NULL,
	"details" varchar,
	"create_date" timestamp DEFAULT now(),
	"update_date" timestamp DEFAULT now(),
	PRIMARY KEY ("id")
);
