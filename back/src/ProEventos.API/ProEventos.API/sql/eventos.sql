create table Eventos
(
    EventoID   INTEGER not null
        constraint PK_Eventos
            primary key autoincrement,
    Local      TEXT,
    DataEvento DATETIME,
    Tema       TEXT,
    QtdPessoas INTEGER,
    Lote       TEXT,
    ImagemURL  TEXT
);

delete from Eventos where EventoID in (1,2,3,4);
insert into Eventos (EventoID, "Local", DataEvento, Tema, QtdPessoas, Lote, ImagemURL)
values (1, 'Curitiba', '20220819', 'Angular 13 e .NET 6', 250, '1 Lote', 'foto.png'),
       (2, 'São Paulo', '20230621', 'Suas Novidades', 550, '2 Lote', 'foto1.png'),
       (3, 'Salvador', '20210621', 'Outro Evento', 50, '3 Lote', 'foto_salvador.png'),
       (4, 'Curitiba', '20221225', 'backend Challenges', 1050, '4 Lote', 'foto_cwb_back.png');