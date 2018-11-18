begin;

create schema if not exists dwh;
create type enum_permission_type as enum ('user', 'analytic', 'admin');

create or replace function now_utc()
  returns timestamp as $$
select now() at time zone 'utc';
$$
language sql;

create table if not exists dwh.resource (
  id   varchar(100) NOT NULL,
  name varchar(100) NOT NULL,
  -- property jsonb        NOT NULL default '{}',
  PRIMARY KEY (id)
);

create table if not exists dwh.source (
  id           varchar(100)    NOT NULL,
  name         varchar(100)    NOT NULL,
  resource_ids varchar(100) [] NOT NULL default array [] :: varchar(100) [],
  PRIMARY KEY (id)
);
create table if not exists dwh.user (
    id          varchar(100)            NOT NULL,
    login       varchar(100)            NOT NULL,
    password    varchar(32)             NOT NULL,
    permissions enum_permission_type [] NOT NULL default array ['user'] :: enum_permission_type [],
    PRIMARY KEY (id)
    );
create table if not exists dwh.statistic (
  id          varchar(100)     NOT NULL,
  source_id   varchar(100)     NOT NULL,
  resource_id varchar(100)     NOT NULL,
  user_id     varchar(100)     NOT NULL,
  created_on  timestamp             DEFAULT now_utc(),
  -- property    jsonb        NOT NULL  default '{}',
  value       double precision NULL default NULL :: double precision,
  PRIMARY KEY (id),
  FOREIGN KEY (source_id) REFERENCES dwh.source (id),
  FOREIGN KEY (resource_id) REFERENCES dwh.resource (id),
  FOREIGN KEY (user_id) REFERENCES dwh.user (id)
);

end 