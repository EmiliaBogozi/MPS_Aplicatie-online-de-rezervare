# MPS_Aplicatie-online-de-rezervare

1.	Scopul documentului

Acest document are rolul de a descrie detaliat şi complet soluţia proiectată pentru sistemul software: „Rezervă-mă – aplicație desktop pentru rezervarea sălilor de la facultate”.


2.	Conţinutul documentului

Documentul este constituit din patru secțiuni. Acestea sunt:
-	Modelul datelor. În această secțiune sunt prezentate structurile de date esențiale în implementarea soluției și schema bazei de date ce stă la baza acesteia.
-	Modelul arhitectural. Această parte este dedicată arhitecturii sistemului.
-	Modelul interfeței cu utilizatorul. Această secțiune prezintă ferestrele vizibile utilizatorului
-	Elemente de testare. Acest segment se ocupă de descrierea componentelor critice ale aplicației și de o descriere generală a potențialelor îmbunătățiri.

3.	Modelul datelor

3.1. Structuri de date globale 

	Structura de date globală folosită este o instanţă a clasei Main, de la care pornește aplicația. Cu ajutorul acestei structuri de date globale, clasele diferitelor module îşi pot accesa reciproc structurile de date interne.


3.2.	Structuri de date de legătură

	Pe parcusul funcționării programului se produc modificări asupra tabelelor din baza de date.

3.3.	Structuri de date temporare
	
	Nu s-au folosit structuri de date temporare care să influențeze soluția.

3.4.	Structura tabelelor

3.4.1.	Tabela Member
	
	member_id – identificatorul utilizatorului;
	first_name – prenumele utilizatorului;
	last_name – numele utilizatorului;
	member_group – grupa din care face parte utilizatorul (e.g. 343C5);
	member_username – username-ul utilizatorul; folosit la logare;
	member_password – parola utilizatorului; folosită la logare;
	member_role – rolul utilizatorului; sunt două: profesor (admin), acesta poate rezerva săli, și student (user), acesta poate doar să vadă sălile rezervate de către profesorul său;

3.4.2.	Tabela Resources
	
	resource_id – identificatorul resursei (sălii);
	resource_name – numele resursei (e.g. EC004);

3.4.3.	Tabela Reservation
	
	reservation_id – identificatorul rezervării;
	resource_id – identificatorul resursei;
	member_id – identificatorul utilizatorului;
	group_reservation – grupa utilizatorului;
	reason_reservation – motivul rezervării; un scurt text pentru justificarea rezervării;
	reservation_year – anul rezervării; parte a datei;
	reservation_month – luna rezervării; parte a datei;
	reservation_day – ziua rezervării; parte a datei;
	reservation_hour –ora  rezervării; parte a datei;
	reservation_minute – minutul rezervării; parte a datei;
	reservation_time – durata în ore a rezervării;

3.4.4.	Tabela Contact2
	
	first_name – prenumele lăsat la contact;
	last_name – numele lăsat la contact;
	email – email-ul lăsat la contact;
	phone_number – numărul de telefon lăsat la contact
	message_text – un mesaj 

3.4.5.	Tabela Favorite_classes
	
	member_id - identificatorul utilizatorului
	resource_id – identificatorul resursei
