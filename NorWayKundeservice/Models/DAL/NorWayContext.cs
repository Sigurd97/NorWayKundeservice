using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeservice.Models
{
    public class NorWayContext : DbContext
    {
        public NorWayContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<FAQ> FAQ { get; set; }

        public DbSet<MainKategori> MainKategorier { get; set; }

        public DbSet<SubKategori> SubKategorier { get; set; }

        public DbSet<FAQInn> FAQInn { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Opprett hovedkategorier
            var hovedKategori1 = new MainKategori() { Id = 1, Navn = "Billetter og setereservasjon" };
            var hovedKategori2 = new MainKategori() { Id = 2, Navn = "Endring, refusjon og kontrollgebyr" };
            var hovedKategori3 = new MainKategori() { Id = 3, Navn = "Bagasje og spesielle behov" };
            var hovedKategori4 = new MainKategori() { Id = 4, Navn = "Trafikk og ruter" };
            var hovedKategori5 = new MainKategori() { Id = 5, Navn = "Kontankt oss " };
            var hovedKategori6 = new MainKategori() { Id = 6, Navn = "Apper, internett og strøm" };
            
            modelBuilder.Entity<MainKategori>().HasData(hovedKategori1, hovedKategori2, hovedKategori3, hovedKategori4, hovedKategori5, hovedKategori6);

            // Opprett underkategorier
            var underKategori1 = new SubKategori() { Id = 1, Navn = "Billetter og rabatter", MainKategoriId = 1 };
            var underKategori2 = new SubKategori() { Id = 2, Navn = "Setereservasjon", MainKategoriId = 1 };
            var underKategori3 = new SubKategori() { Id = 3, Navn = "Samarbeid med lokale operatører", MainKategoriId = 1 };

            var underKategori4 = new SubKategori() { Id = 4, Navn = "Endring, refusjon og kontrollgebyr", MainKategoriId = 2 };

            var underKategori5 = new SubKategori() { Id = 5, Navn = "Bagasje og kjæledyr", MainKategoriId = 3 };
            var underKategori6 = new SubKategori() { Id = 6, Navn = "Tilgjengelighet for funksjonshemmede", MainKategoriId = 3 };
            var underKategori7 = new SubKategori() { Id = 7, Navn = "Reise med barn", MainKategoriId = 3 };

            var underKategori8 = new SubKategori() { Id = 8, Navn = "Trafikk og ruter", MainKategoriId = 4 };

            var underKategori9 = new SubKategori() { Id = 9, Navn = "Kontakt informasjon", MainKategoriId = 5 };

            var underKategori10 = new SubKategori() { Id = 10, Navn = "NorWay Buss appen", MainKategoriId = 6 };
            var underKategori11 = new SubKategori() { Id = 11, Navn = "Underholdning under turen", MainKategoriId = 6 };
            var underKategori12 = new SubKategori() { Id = 12, Navn = "Internett og strøm", MainKategoriId = 6 };

            modelBuilder.Entity<SubKategori>().HasData(underKategori1, underKategori2, underKategori3, underKategori4, underKategori5, underKategori6, underKategori7, underKategori8, underKategori9, underKategori10, underKategori11, underKategori12);

            // Opprett FAQs
            FAQ faq1 = new FAQ() { Id = 1, Spørsmål = "Hvordan kjøper jeg billett?", SubKategoriId = 1, Rating = 5, Svar = "<li>https://www.nor-way.no/#/</li> <li>Prøv vår nye Norway busss app</li> <li>Om bord på bussen</li>"};
            FAQ faq2 = new FAQ() { Id = 2, Spørsmål = "Er det mulig å kjøpeperiodebillett?", SubKategoriId = 1, Rating = 4, Svar = "<p>Det enkleste for deg er å kjøpe periodebillette på nettsiden vår https://www.nor-way.no/#/ eller i vår app" };
            FAQ faq3 = new FAQ() { Id = 3, Spørsmål = "Hvordan henter jeg billetter kjøpt på Norwaybuss.no?", SubKategoriId = 1, Rating = 3, Svar = "<p>Det enkleste er å hente ut billetten via appen. Den kan også laste den ned å skrive ut i PDF" };
            FAQ faq4 = new FAQ() { Id = 4, Spørsmål = "Jeg vil betale for buss billetten med faktura – hvordan gjør jeg det?", SubKategoriId = 1, Rating = 4, Svar = "<p>Privatpersoner kan velge faktura ved betaling på norwaybuss.no. Minstebeløpet er 500 kr og du må betale fakturagebyr på 40 kr.<" };
            FAQ faq5 = new FAQ() { Id = 5, Spørsmål = "Jeg har kjøpt billett hos dere. Hvorfor har jeg ikke fått kvittering på e-post?", SubKategoriId = 1, Rating = 1, Svar = "<p>Det kan være forskjellige grunner til dette:</p> <ul> <li>Du var ikke innlogget ved kjøp og oppga feil e-postadresse. Ta i så fall kontakt med kundeservice for å få tilsendt kvittering.</li>" };
           
            FAQ faq6 = new FAQ() { Id = 6, Spørsmål = "Kan jeg reservere sete på bussen?", SubKategoriId = 2, Rating = 3, Svar = "<p>Nei, det er ikke mulig. Du kan sitte foran hvis du blir lette bilsyk</p>" };
            FAQ faq7 = new FAQ() { Id = 7, Spørsmål = "Har dere dyrefri sone for meg som er allergisk?", SubKategoriId = 2, Rating = 5, Svar = "<p>Bussene vår blir dyrefri samt noen oppgir at de er allergiske</p>" };

            FAQ faq8 = new FAQ() { Id = 8, Spørsmål = "Hvordan er samarbeidet mellom NorWay og Ruter?", SubKategoriId = 3, Rating = 2, Svar = "<p>Vi har ingen samarbeid, desverre....</p> "};

            FAQ faq9 = new FAQ() { Id = 9, Spørsmål = "Hvordan kan jeg endre eller refundere billetten?", SubKategoriId = 4, Rating = 5, Svar = "<p>Hvis du har enkeltbillett og vil endre eller refundere kan du kjøre det på Mine sider i appen eller på vår nettside</p>"};

            FAQ faq10 = new FAQ() { Id = 10, Spørsmål = "Jeg har glemt noe om bord. Hvordan kontakter jeg dere om hittegods?", SubKategoriId = 5, Rating = 4, Svar = "<p>Kontakt kundeservice på telefon eller epost</p>" };
            FAQ faq11 = new FAQ() { Id = 11, Spørsmål = "Hvor mye bagasje kan jeg ha med?", SubKategoriId = 5, Rating = 5, Svar = "<p>Du kan ta med deg inntil 30 kilo fordelt på maksimum 3 kolli</p>" };
            FAQ faq12 = new FAQ() { Id = 12, Spørsmål = "Kan jeg ha med kjæledyr?", SubKategoriId = 5, Rating = 3, Svar = "<p>Ja, så lenge ingen på bussen har oppgitt noen allergier</p>" };

            FAQ faq13 = new FAQ() { Id = 13, Spørsmål = "Hvordan bestiller jeg billett hvis jeg har spesielle behov for reisen?", SubKategoriId = 6, Rating = 3, Svar = "<p>Du legger deet til ved kjøp av billett</p>" };
            FAQ faq14 = new FAQ() { Id = 14, Spørsmål = "Hva slags rabatter tilbyr dere for eldre?", SubKategoriId = 6, Rating = 3, Svar = "<p>Alltid rabatt på honnør!!</p>" };
            FAQ faq15 = new FAQ() { Id = 15, Spørsmål = "Kan jeg få assistanse på bussholdeplassen?", SubKategoriId = 6, Rating = 3, Svar = "<p>Ja busssjåføren er en mann med godt humør!</p>" };

            FAQ faq16 = new FAQ() { Id = 16, Spørsmål = "Kan jeg ha med barnevogn?", SubKategoriId = 7, Rating = 1, Svar = "<p>Du kan ta med én barnevogn pr. voksen – helt gratis. Det er plass til barnevogner under bussen.</p>" };
            FAQ faq17 = new FAQ() { Id = 17, Spørsmål = "Hva koster barnebillett? Er det familierabatt?", SubKategoriId = 7, Rating = 5, Svar = "Barn Har fast lav pris til det året de fyller 16 år." };
     

            FAQ faq18 = new FAQ() { Id = 18, Spørsmål = "Hvordan finner jeg ut om bussen er i rute?", SubKategoriId = 8, Rating = 4, Svar = "<p>Dette kan u raskt finne ut av på vår nettside eller app</p>" };
            FAQ faq19 = new FAQ() { Id = 19, Spørsmål = "Hvordan finner jeg rutetidene?", SubKategoriId = 8, Rating = 5, Svar = "<p>Du kan raskt og enkelt gjøre ved å ta et rutesøk på vår nettside eller i appen.</p>" };
      

            FAQ faq20 = new FAQ() { Id = 20, Spørsmål = "Er det planlagte stopp for å kjøpe mat osv?", SubKategoriId = 9, Rating = 2, Svar = "<p>Vi stopper ikke på noen holdeplassser under turen</p>" };
            FAQ faq21 = new FAQ() { Id = 21, Spørsmål = "Kan jeg ta med egen mat på bussen?", SubKategoriId = 9, Rating = 5, Svar = "<p>Ja, det går fint å spise medbragt mat på bussen. Vi ønsker at passajerer nyter alkohol</p>" };

            FAQ faq22 = new FAQ() { Id = 22, Spørsmål = "Hvordan laster jeg ned appen?", SubKategoriId = 10, Rating = 4, Svar = "<p>Du kan laste ned appen på App Store eller Google Play</p>" };
            FAQ faq23 = new FAQ() { Id = 23, Spørsmål = "Hva kan jeg gjøre i appen?", SubKategoriId = 10, Rating = 4, Svar = "<li>Kjøpe bussbilletter og periodebilletter</li> <li>Sjekke busstider</li> <li>Få varsel om endringer eller avvik som påvirker avgangen din</li> <li>Få oppdatert reiseinformasjon</li></ul>" };
            FAQ faq24 = new FAQ() { Id = 24, Spørsmål = "Hvordan betaler jeg?", SubKategoriId = 10, Rating = 1, Svar = "<p>Du kan betale med kredittkort eller Vipps.</p>" };
            FAQ faq25 = new FAQ() { Id = 25, Spørsmål = "Jeg har slettet appen og billetten(e) er borte. Hva gjør jeg?", SubKategoriId = 10, Rating = 5, Svar = "<p>Da må du kontakte kundeservice sånn at vi kan tilbakestille billetten din.</p>" };

            FAQ faq26 = new FAQ() { Id = 26, Spørsmål = "Hvorfor får jeg melding om «ikke gyldig billett» selv om jeg har periodebillett?", SubKategoriId = 11, Rating = 5, Svar = "<p>Enkelte kunder som har periodebillett på reisekort kan oppleve å få melding i underholdningsappen om «ikke gyldig billett» ved nedlasting av aviser og lydbøker, selv om billetten er aktivert på reisekortet. Vi har dessverre ingen umiddelbar løsning på dette problemet, men har du anledning anbefaler vi deg å kjøpe billettene dine i Vy-appen for å få tilgang til aviser og lydbøker.</p>" };
            FAQ faq27 = new FAQ() { Id = 27, Spørsmål = "Hvilken versjon av Android og iOS krever det at jeg har installert på mobilen?", SubKategoriId = 11, Rating = 1, Svar = "<p>For Android støttes OS versjon 4.0 og senere, for iOS støttes iOS versjon 7.0 og senere.</p>" };
 
            FAQ faq28 = new FAQ() { Id = 28, Spørsmål = "Hvordan er WiFi på bussen?", SubKategoriId = 11, Rating = 3, Svar = "<p>Alle våre busser har nyeste og beste Wifi!!</p>" };
            FAQ faq29 = new FAQ() { Id = 29, Spørsmål = "Er det internett på bussen?", SubKategoriId = 12, Rating = 4, Svar = "<p> Vi til byr Wifi på alle våre busser.</p>" };
            FAQ faq30 = new FAQ() { Id = 30, Spørsmål = "Er det strømuttak om bord?", SubKategoriId = 12, Rating = 5, Svar = "<p>Det er strømuttak på alle bussene.</p>" };
            
            modelBuilder.Entity<FAQ>().HasData(faq1, faq2, faq3, faq4, faq5, faq6, faq7, faq8, faq9, faq10, faq11, faq12, faq13, faq14, faq15, faq16, faq17, faq18, faq19, faq20, faq21, faq22, faq23, faq24, faq25, faq26, faq27, faq28, faq29, faq30);

            FAQInn faqInnsendt1 = new FAQInn() { Id = 1, Fornavn = "Sigurd", Etternavn = "Skogen", Epost = "sigurd.skogen@gmail.com", MainKategoriId = 1, SubKategoriId = 1, Spørsmål = "Hvor mange billetter kan jeg kjøpe?" };
            FAQInn faqInnsendt2 = new FAQInn() { Id = 2, Fornavn = "ole", Etternavn = "Foss", Epost = "oleFoss@gmail.com", MainKategoriId = 2, SubKategoriId = 4, Spørsmål = "Kan jeg få pengene mine tilbake?" };

            modelBuilder.Entity<FAQInn>().HasData(faqInnsendt1, faqInnsendt2);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB;database=NorwayKundeserviceDatabase;trusted_connection=true;");
        }

    }
}



