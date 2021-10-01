--
-- File generated with SQLiteStudio v3.3.3 on dim. jui. 6 10:16:02 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: marche
CREATE TABLE marche(
    numMarche varchar(50) primary key, --1
    liaison varchar(900),--2
    titulaire varchar(255),--3
    delai int,--4
    cout decimal(8,2),--5
    osce date,--6
    finDelTh date,--7
    totJrArr int,--8
    finDelcmptArr date,--9
    paimEff decimal(8,2),--10
    avcmtcmpt decimal(4,2),--11
    observ varchar(500)--12

);
INSERT INTO marche VALUES ('02/2017', 'renforcement de la RP 3506 du PK 0+000 au PK 19+152 et la RP 3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');
INSERT INTO marche VALUES ('02/2018', 'Etude d elargissement et renforcement de la RP 3506 du PK 0+000 au PK 19+152 et la RP 3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');
INSERT INTO marche VALUES ('02/2019', 'PK 0+000 au PK 19+152 et la RP 3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');
INSERT INTO marche VALUES ('02/2020', 'Etude d elargissement et renforcement de la RP 3506 du PK 0+000 au PK 19+152 et la RP 3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');
INSERT INTO marche VALUES ('02/2021', '3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');
INSERT INTO marche VALUES ('02/2022', 'elargissement et renforcement de la RP 3506 du PK 0+000 au PK 19+152 et la RP 3507 du PK 0+000 au PK 27+262', 'GISEMENT ETUDES ET TRAVAUX', 270, 257952, '2017-10-07', '2018-07-04', 672, '2020-05-06', 83712, 32.45, 'myObserv');

-- Table: nbJrArr
CREATE TABLE nbJrArr(
    id_nbJrArr int primary key AUTOINCREMENT,
    nbJrArr int,
    id_marche varchar(50) references marche(numMarche)
);
INSERT INTO nbJrArr VALUES (1, 25, '02/2017');
INSERT INTO nbJrArr VALUES (2, 13, '02/2019');
INSERT INTO nbJrArr VALUES (4, 12, '02/2022');
INSERT INTO nbJrArr VALUES (8, 43, '02/2018');

-- Table: osae
CREATE TABLE osae(
    id_osea int primary key AUTOINCREMENT,
    osae date not null,
    id_marche varchar(50) references marche(numMarche)
);
INSERT INTO osae VALUES (1, '2017-11-08', '02/2017');
INSERT INTO osae VALUES (2, '2017-11-08', '02/2019');
INSERT INTO osae VALUES (3, '2017-11-08', '02/2022');
INSERT INTO osae VALUES (4, '2017-11-08', '02/2018');

-- Table: osre
CREATE TABLE osre(
    id_osre int primary key AUTOINCREMENT,
    osre date not null,
    id_marche varchar(50) references marche(numMarche)
);
INSERT INTO osre VALUES (1, '2018-10-15', '02/2017');
INSERT INTO osre VALUES (2, '2018-10-15', '02/2017');
INSERT INTO osre VALUES (3, '2018-10-15', '02/2017');
INSERT INTO osre VALUES (4, '2018-10-15', '02/2017');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
