-- Creation of product table
CREATE TABLE IF NOT EXISTS DailyEntries (
  CreatedAt TIMESTAMP  NOT NULL,
  Amount DECIMAL(10,2) NOT NULL,
  OperationTypeId SMALLINT NOT NULL,
  Id UUID NOT NULL PRIMARY KEY
);