USE 3a2_zykamatej_db1;


CREATE TABLE BK_RECEIPT_ITEM
(
  ID                    INT             AUTO_INCREMENT  NOT NULL,
  RECEIPT_ID            INT                             NOT NULL,
  ORDINAL               INT                             NOT NULL,
  DESCRIPTION           VARCHAR(200)                        NULL,
  ACCOUNTING_CODE_ID    INT                             NOT NULL,
  AMOUNT                DECIMAL(10,2)                   NOT NULL,

  CONSTRAINT PK_BK_RECEIPT_ITEM  PRIMARY KEY (ID),
  CONSTRAINT FK_BK_RECEIPT_ITEM_BK_RECEIPT  FOREIGN KEY (RECEIPT_ID) REFERENCES BK_RECEIPT (ID),
  CONSTRAINT FK_BK_RECEIPT_ITEM_BK_ACCOUNTING_CODE  FOREIGN KEY (ACCOUNTING_CODE_ID) REFERENCES BK_ACCOUNTING_CODE (ID)
);
