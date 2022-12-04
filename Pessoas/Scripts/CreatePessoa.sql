
use Pessoa

CREATE TABLE PESSOA (
  IDPESSOA          int identity(1,1)        PRIMARY KEY,
  NAME       VARCHAR(50)   NOT NULL,
  ADDRESS   VARCHAR(50)  NOT NULL,
);