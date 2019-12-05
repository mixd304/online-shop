/*1 */ INSERT INTO Kategorien(Bezeichnung) VALUES ('Smartphones');
/*2 */ INSERT INTO Kategorien(Bezeichnung) VALUES ('Laptops');
/*3 */ INSERT INTO Kategorien(Bezeichnung) VALUES ('Hardware');
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Apple iPhone 8','Genau was du willst, exakt was du brauchst.',529,1);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Apple iPhone 11','Genau was du willst, exakt was du brauchst.',799.99,1);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('ASUS ROG STRIX NVIDIA GeForce RTX 2080 Ti OC','Grafikprozessorenfamilie: NVIDIA, GPU: GeForce RTX 2080 Ti, Prozessor-Taktfrequenz: 1350 MHz. Separater Grafik-Adapterspeicher: 11 GB, Grafikkartenspeichertyp: GDDR6, Speichertaktfrequenz: 14000 MHz. Maximale Auflösung: 7680 x 4320 Pixel. DirectX-Version:Prozessor Prozessor-Taktfrequenz : 1350 MHz GPU : GeForce RTX 2080 Ti Maximale Auflösung : 7680 x 4320 Pixel Parallele Verarbeitungstechnologie : Crossfire Maximale Displays pro Videokarte : 4 CUDA : Ja CUDA-Kerne',1329,3);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('HP 250 G7 6HM78ES 15,6"','Gutes Teil',299,2);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Acer Aspire 5 (A514-52-58NK)','Mit dem Acer Aspire 5 (A514-52-58NK) kannst Du dank des schlanken, leichten Designs und der sandgestrahlten oberen Abdeckung aus Aluminium stilvoll reisen. Dieses schlanke Notebook ist lediglich 17,95 mm dünn und die glatte, angenehme Haptik vollendet das Premiumdesign mit edlem Look. Mit einer Akkulaufzeit von bis zu 12,5 Stunden ist Dein Notebook der perfekte Begleiter für den ganzen Tag.',699,2);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Apple iPhone XR','Genau was du willst, exakt was du brauchst.',699,1);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Asus ZenBook 14 UM431DA-AM058T','Kreativität. Stil. Innovation. Das sind Qualitätsmerkmale, die das elegante neue ZenBook 14 auszeichnen. In diesem superkompakten Meisterwerk ist alles so konzipiert, dass Sie die Freiheit haben, Ihre kreative Vision zu entdecken, einschließlich des atemberaubenden schmalen NanoEdge-Displays mit 86% Screen-to-Body-Ratio. Sie werden nicht nur die ungeheure Kraft im Inneren und die durchdachte Liebe zum Detail - wie das exklusive ErgoLift-Kippscharnier und das optionale NumberPad-Touchpad - schätzen, sondern auch die zeitlose Schönheit des Designs mit seinem edlen Finish Utopia Blue, das durch das stilvolle silberne Zierfeld noch verstärkt wird. Das ZenBook 14 wartet: Sind Sie bereit, Ihre kreative Vision zu verwirklichen?',555,2);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Acer Aspire 3 A315-55G-54V9','Dünnes, hochwertiges Aluminum Design mit gebürsteten Aluminumcover bietet atemberaubende Optik...',555,2);
INSERT INTO Artikel(Bezeichnung, Beschreibung, Preis, Kategorie_ID) VALUES ('Samsung Galaxy s10','Zehn Jahre Galaxy-Erfahrung sind in die Entwicklung des neuen Galaxy S10 geflossen – und das sieht man nicht nur, man spürt es auch. Das Ergebnis: Ein Smartphone, das schneller, intelligenter und hochwertiger ist als je ein Galaxy Smartphone zuvor. Hinter dem farbintensiven Infinity-O Display steckt mit dem Ultraschall-Fingerabdruckscanner ein Stück Zukunft, das begeistert. Das Galaxy S10 denkt mit. Es lernt dazu. Es teilt. Und es ist dafür gemacht, für jeden Alltag der passende Begleiter zu sein.',599.99,1);
/*1 */ INSERT INTO Farben(Bezeichnung) VALUES ('Space Grau');
/*2 */ INSERT INTO Farben(Bezeichnung) VALUES ('Roségold');
/*3 */ INSERT INTO Farben(Bezeichnung) VALUES ('Silber'); 
/*4 */ INSERT INTO Farben(Bezeichnung) VALUES ('Schwarz');
/*5 */ INSERT INTO Farben(Bezeichnung) VALUES ('Weiß');
INSERT INTO ArtikelFarben(Artikel_ID, Farbe_ID) VALUES (1,1);
INSERT INTO ArtikelFarben(Artikel_ID, Farbe_ID) VALUES (1,2);
INSERT INTO ArtikelFarben(Artikel_ID, Farbe_ID) VALUES (1,3);
INSERT INTO ArtikelFarben(Artikel_ID, Farbe_ID) VALUES (2,2);
INSERT INTO ArtikelFarben(Artikel_ID, Farbe_ID) VALUES (2,3);
/*1 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Videowiedergabe');
/*2 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Display'); 
/*3 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Kamera'); 
/*4 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('RAM'); 
/*5 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('CPU'); 
/*6 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Festplatte'); 
/*7 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Auflösung'); 
/*8 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Speicher'); 
/*9 */ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Grafikkarte');
/*10*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Displaygröße'); 
/*11*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Modell/ Serie');
/*12*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Gewicht'); 
/*13*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Prozessorgeschwindigkeit'); 
/*14*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Grafikkartenspeicher'); 
/*15*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Interface'); 
/*16*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Watt'); 
/*17*/ INSERT INTO MerkmalBezeichnungen(Bezeichnung) VALUES ('Monitor'); 
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (1,'bis zu 14 Stunden',1);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (1,'bis zu 16 Stunden',6);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (1,'bis zu 17 Stunden',2);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (2,'4,7'''' oder 5,5'''' Retina HD Display',1);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (3,'Ein‑Kamera-System (Weitwinkel) oder Zwei‑Kamera-System (Weitwinkel, Teleobjektiv)',1);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (2,'6,1'''' Liquid Retina HD Display',6);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (2,'6,1'''' Liquid Retina HD Display',2);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'Ein‑Kamera-System (Weitwinkel)',6);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'Neues Zwei‑Kamera-System (Ultraweitwinkel, Weitwinkel',2);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (17,'Entspiegeltes 15,6"-Display mit einer Full HD Auflösung von 1920 x 1080 Pixeln',4);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'8GB',4);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (5,'Intel I7 8700K',4);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (6,'500 GB SSD',4);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (7,'1920 x 1080 (Full HD Acer ComfyView™)',5);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (8,'1.000 GB M.2 PCIe Solid-State-Drive (SSD)',5);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (9,'Intel UHD Graphics 620',5);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'8 GB DDR4 RAM',5);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'8 GB LPDDR3',7);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (5,'AMD Ryzen 5 3500U Prozessor 4x 2.10 GHz',7);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (10,'35,56 cm (14")',7);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'8 GB DDR4',8);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (5,'Intel® Core™ i5 (8. Generation) 8265U Prozessor 4x 1,60 GHz',8);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (9,'GeForce MX230',8);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (11,'ROG-STRIX-RTX2080TI-O11G-GAMING',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (12,'998g',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (4,'11 GB',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (6,'11264 MB',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (13,'1350 MHz',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (14,'GDDR6',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (15,'PCI-E',3);
INSERT INTO Merkmale(Bezeichnung_ID, Wert, Artikel_ID) VALUES (16,'650 Watt',3);
INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Name, Plz, Ort, Strasse, Hausnummer, Geburtsdatum) VALUES ('391c3801-312d-4b83-bd04-a6ece6a33cd4','d.mix@dvz-mv.de','D.MIX@DVZ-MV.DE','d.mix@dvz-mv.de','D.MIX@DVZ-MV.DE',1,'AQAAAAEAACcQAAAAEAJKe5wVtJZosRHKMQ5pQ4jcBbT2PBmuufRGWiaYE2vNL+w+pLlsMM5q9ErSvLpdOg==','B3ZKURE3TIKM3FWTZMUJ6UEU7ABP37IR','4a2fa1b9-68fe-46f4-9ba5-11bd7981a112',NULL,0,0,NULL,1,0,' Darius Mix','10178','Berlin','Alexanderplatz','1','2019-01-01 00:00:00');
INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Name, Plz, Ort, Strasse, Hausnummer, Geburtsdatum) VALUES ('5a182953-ef4b-4f87-b3a3-b51c22d3b88b','t.vinzing@dvz-mv.de','T.VINZING@DVZ-MV.DE','t.vinzing@dvz-mv.de','T.VINZING@DVZ-MV.DE',1,'AQAAAAEAACcQAAAAEMaqE0TOkc5O9Asgv38gwW5Nc/IBbH03MeWPYe4OzWo9aR1Xum6RaBxU1cw9s+RxTw==','ZF2WFNABN2B63TENWDSFIKSSDI2UNL2U','63d13574-48ac-48c0-9838-43370414de12',NULL,0,0,NULL,1,0,'Tim Vinzing','10178','Berlin','Alexanderplatz','1','2019-12-31 00:00:00');
INSERT INTO Kommentare(Inhalt, Bewertung, Artikel_ID, Nutzer_ID, Datum) VALUES ('Sehr geil',2,1,'391c3801-312d-4b83-bd04-a6ece6a33cd4','2019-12-04 19:04:00');
INSERT INTO Kommentare(Inhalt, Bewertung, Artikel_ID, Nutzer_ID, Datum) VALUES ('noch geiler',3,2,'391c3801-312d-4b83-bd04-a6ece6a33cd4','2019-12-03 16:36:55');
INSERT INTO Kommentare(Inhalt, Bewertung, Artikel_ID, Nutzer_ID, Datum) VALUES ('am geilsten',5,3,'5a182953-ef4b-4f87-b3a3-b51c22d3b88b','2019-12-05 07:52:05');
INSERT INTO Kommentare(Inhalt, Bewertung, Artikel_ID, Nutzer_ID, Datum) VALUES ('finde ich auch sehr sehr geil',4,3,'391c3801-312d-4b83-bd04-a6ece6a33cd4','2019-12-02 14:09:36');
/*1 */ INSERT INTO Bestellungen(Gesamtpreis, Bestelldatum, Status, Nutzer_ID) VALUES (199.99,'2019-12-04 19:04:00','Eingegangen','391c3801-312d-4b83-bd04-a6ece6a33cd4')
/*2 */ INSERT INTO Bestellungen(Gesamtpreis, Bestelldatum, Status, Nutzer_ID) VALUES (199.99,'2019-12-04 19:04:00','Eingegangen','391c3801-312d-4b83-bd04-a6ece6a33cd4')
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (2,1,1,3);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (8,1,1,2);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (2,3,1,NULL);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (10,1,2,1);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (8,2,2,3);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (1,5,2,NULL);
INSERT INTO ArtikelBestellungen(Anzahl, Artikel_ID, Bestellung_ID, Farbe_ID) VALUES (1,6,2,NULL);