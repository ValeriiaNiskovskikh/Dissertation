begin;

create schema if not exists dwh;
create type enum_permission_type as enum ('user', 'analytic', 'admin');

create or replace function now_utc()
  returns timestamp as $$
select now() at time zone 'utc';
$$
language sql;

create table if not exists dwh.resource (
  id   bigserial NOT NULL,
  name varchar(100) NOT NULL,
  -- property jsonb        NOT NULL default '{}',
  PRIMARY KEY (id)
);

create table if not exists dwh.source (
  id           bigserial    NOT NULL,
  name         varchar(100)    NOT NULL,
  resource_ids bigint [] NOT NULL default array [] :: bigint [],
  PRIMARY KEY (id)
);
create table if not exists dwh.user (
    id          bigserial            NOT NULL,
    login       varchar(100)            NOT NULL,
    password    varchar(32)             NOT NULL,
    permissions enum_permission_type [] NOT NULL default array ['user'] :: enum_permission_type [],
    PRIMARY KEY (id)
    );

CREATE TABLE if not exists dwh.assay
(
    id bigserial PRIMARY KEY,
    created_on timestamp,
    source_id bigint,
    user_id bigint,
    CONSTRAINT assay_user_id_fk FOREIGN KEY (user_id) REFERENCES dwh."user" (id),
    CONSTRAINT assay_source_id_fk FOREIGN KEY (source_id) REFERENCES dwh.source (id)
);

create table if not exists dwh.assay_value(
    id bigserial PRIMARY KEY ,
    assay_id bigint,
    resource_id bigint,
    assay_value double precision ,
    CONSTRAINT assay_value_assay_id_fk FOREIGN KEY (assay_id) REFERENCES dwh.assay (id),
    CONSTRAINT assay_value_resource_id_fk FOREIGN KEY (resource_id) REFERENCES dwh.resource (id)

);
CREATE UNIQUE INDEX assay_id_uindex ON dwh.assay (id);
end 