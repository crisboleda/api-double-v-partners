
\connect double_v_partners

CREATE TABLE ticket_status (
  id SERIAL PRIMARY KEY,
  description varchar(45) NOT NULL,
  UNIQUE(id)
);

CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  name varchar(45) NOT NULL,
  username varchar(20) NOT NULL,
  email varchar(80) NOT NULL,
  UNIQUE(id)
);

CREATE TABLE tickets (
  id SERIAL PRIMARY KEY,
  user_id integer NOT NULL,
  status_id integer NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  UNIQUE(id),
  CONSTRAINT status_ticket FOREIGN KEY (status_id) REFERENCES ticket_status (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT users_tickets FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE ON UPDATE CASCADE
);

ALTER TABLE ticket_status OWNER TO developer_double;
ALTER TABLE users OWNER TO developer_double;
ALTER TABLE tickets OWNER TO developer_double;

INSERT INTO users ("name", "username", "email") VALUES ('Bill Gates','Bill','billgates@gmail.com');
INSERT INTO ticket_status ("description") VALUES ('Abierto'),('Cerrado');
INSERT INTO tickets ("user_id", "status_id") VALUES (1, 2);


CREATE OR REPLACE FUNCTION update_changetimestamp_column()
RETURNS TRIGGER AS $$
BEGIN
   NEW.updated_at = now(); 
   RETURN NEW;
END;
$$ language 'plpgsql';

CREATE TRIGGER update_ab_changetimestamp BEFORE UPDATE
    ON tickets FOR EACH ROW EXECUTE PROCEDURE 
    update_changetimestamp_column();
