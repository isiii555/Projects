
import random
from time import sleep
import os

question1 = ["1. 50 manatliq SUAL : Avropanin en boyuk valyutasi hansidir?",
             "1. 50 manatliq SUAL : Azerbaycanda pul vahidi hansidir?",
             "1. 50 manatliq SUAL : Azerbaycanin paytaxti hansi seherdir?",
             "1. 50 manatliq SUAL : Azerbaycanin prezidenti kimdir?",
             "1. 50 manatliq SUAL : Azerbaycanin musteqillik gunu ne vaxtdir?"]
answers1 = [["A) Lira","B) Rubl","C) Manat", "D) Euro"],
            ["A) Lira", "B) Rubl", "C) Manat", "D) Euro"],
            ["A) Baki", "B) Gence","C) Masalli","D) Sheki"],
            ["A) Vilayet Eyvazov", "B) Ilham Eliyev","C) Elza Seyidcahan","D) Namiq Rasullu"],
            ["A) 9 may", "B) 1 aprel","C) 18 dekabr","D) 28 may"]
            ]
correct1 = ["D",
            "C",
            "A",
            "B",
            "D"]
amount1 = 50
audience1 = [["A: 22%", "B: 2%", "C: 0%", "D: 76%"],
             ["A: 22%", "B: 2%", "C: 76%","D: 0%"],
             ["A: 76%", "B: 2%", "C: 22%","D: 0%"],
             ["A: 22", "B: 76%", "C: 2%","D: 0%"],
             ["A: 22", "B: 0%", "C: 2%","D: 76%"]]
phone1 = ["Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi D bendidir!"]



question2 = ["2. 100 manatliq SUAL : Bu heyvanlardan hansi qurbanini bogaraq oldurur?",
             "2. 100 manatliq SUAL : Mektebe geden ve ya imtahan giren sagirde hansi arzunu dileyirler?",
             "2. 100 manatliq SUAL : Fiziki xeritelerde daglar hansi rengde gosterilir?",
             "2. 100 manatliq SUAL : Mantinin xemiri adeten hansi formada kesilir?",
             "2. 100 manatliq SUAL : Axici,tesirli ve ritmli danishan shexslerin nitqi hansina benzedilir?"]
answers2 = [
            ["A) Pisik", "B) Anaconda", "C) Fil", "D) Qoyun"],
            ["A) Allah beterinden saxlasin", "B) Allah zehin acigligi versin", "C) Allah komeyin olsun", "D) Allah xoshbext elesin"],
            ["A) Yasil", "B) Qirmizi","C) Qehveyi","D) Mavi"],
            ["A) Ucbucaq", "B) Duzbucaqli","C) Daire","D) Kvadrat"],
            ["A) Seir", "B) Meyxana","C) Dastan","D) Nagil"]
            ]
correct2 = ["B",
            "B",
            "C",
            "D",
            "A"]
amount2 = 100
audience2 = [
             ["A: 2%", "B: 95%", "C: 2%", "D: 1%"],
             ["A: 22%", "B: 76%", "C: 2%", "D: 0%"],
             ["A: 2%", "B: 2%", "C: 95%", "D: 1%"],
             ["A: 2%", "B: 1%", "C: 2%", "D: 95%"],
             ["A: 95%", "B: 3%", "C: 2%", "D: 0%"]
             ]
phone2 = ["Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi A bendidir!"]


question3 = ["3. 200 manatliq SUAL: Azerbaycanin onceden paytaxti olmus seheri hansidir?",
             "3. 200 manatliq SUAL : Hansi ev qusu 'zengli saat' rolunu oynayir?",
             "3. 200 manatliq SUAL : Neyin lepesini yemirler?",
             "3. 200 manatliq SUAL : Shovket Elekberovanin ifa etdiyi mahnida hansi ag xalatli peshe sahiblerinden behs olunur?",
             "3. 200 manatliq SUAL : Basketbolda topu haradan kecirirler?"]
answers3 =  [
            ["A) Balaken", "B) Masalli", "C) Gence", "D) Sheki"],
            ["A) Toyuq", "B) Qaz", "C) Ordek", "D) Xoruz"],
            ["A) Qoz", "B) Deniz","C) Badam","D) Findiq"],
            ["A) Muellimler", "B) Hekimler","C) Muhendisler","D) Jurnalistler"],
            ["A) Sebet", "B) Kise","C) Xurcun","D) Heybet"]
            ]
correct3 = ["C",
            "D",
            "B",
            "B",
            "A"]
amount3 = 200
audience3 = [
             ["A: 2%", "B: 2%", "C: 95%", "D: 1%"],
             ["A: 3%", "B: 10%", "C: 12%","D: 75%"],
             ["A: 13%", "B: 75%", "C: 10%","D: 2%"],
             ["A: 10%", "B: 75%", "C: 13%","D: 2%"],
             ["A: 95%", "B: 3%", "C: 2%","D: 0%"]
             ]
phone3 = ["Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi A bendidir!"]

question4 = ["4. 300 manatliq SUAL: Cox melumatli adami el arasinda ne adlandirirlar?",
             "4. 300 manatliq SUAL : Ukrayna parlamenti nece adlanir?",
             "4. 300 manatliq SUAL : Hansi soz yapon dilinden tercumede muqeddes kulek menasini verir?",
             "4. 300 manatliq SUAL : Ashagidakilerden hansi hecmce daha az su tutur?",
             "4. 300 manatliq SUAL : Badminton oyunu hansi oyuna benzeyir?"]
answers4 =  [
            ["A) Qelender", "B) Gulenber", "C) Bilender", "D) Culender"],
            ["A) Rikstaq", "B) Dovlet Dumasi", "C) Ali Rada", "D) Bundestaq"],
            ["A) Tornado", "B) Tayfun","C) Sunami","D) Kamikadze"],
            ["A) Stekan", "B) Vedre","C) Cellek","D) Sistern"],
            ["A) Qolf", "B) Qilincoynatma","C) Handbol","D) Tennis"]
            ]

correct4 = ["C",
            "C",
            "D",
            "A",
            "D"]
amount4 = 300
audience4 = [
             ["A: 2%", "B: 2%", "C: 95%", "D: 1%"],
             ["A: 2%", "B: 2%", "C: 95%","D: 1%"],
             ["A: 2%", "B: 3%", "C: 0%","D: 95%"],
             ["A: 75%", "B: 13%", "C: 10%","D: 2%"],
             ["A: 3%", "B: 3%", "C: 2%","D: 92%"]
             ]
phone4 = ["Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi D bendidir!"]

question5 = ["5. 500 manatliq SUAL: Futbol oyununda stadionda cemi nece oyuncu olur?",
             "5. 500 manatliq SUAL: Amerikani kesf etmis Xristofor Kolumb harani kesf etdiyini zenn edirdi?",
             "5. 500 manatliq SUAL: Cografi xeriteler toplusu nece adlanir?",
             "5. 500 manatliq SUAL: Musiqili Komediya kinoteatri kimin adinadir?",
             "5. 500 manatliq SUAL: Informasiya Texnologiyalari muelliminin adi nedir?"]
answers5 = [
            ["A) 20", "B) 24", "C) 21", "D) 22",],
            ["A) Hindistan", "B) Avstraliya", "C) Avstriya", "D) Azerbaycan"],
            ["A) Almaz", "B) Atlas" , "C) Astar" , "D)Alqasim"],
            ["A) Molla Nesreddin", "B) Celil Memmedquluzade", "C) Heyder Eliyev", "D) Akif Islamzade"],
            ["A) Ali-Mehemmed", "B) Namiq Rasullu", "C) Islam Salamzade", "D) Hakuna Matata"]
           ]
correct5 = ["D",
            "A",
            "B",
            "A",
            "A"]
amount5 = 500

audience5 = [
             ["A: 2%", "B: 2%", "C: 1%", "D: 95%"],
             ["A: 95%", "B: 2%", "C: 2%","D: 1%"],
             ["A: 2%", "B: 95%", "C: 0%","D: 3%"],
             ["A: 75%", "B: 13%", "C: 10%","D: 2%"],
             ["A: 92%", "B: 3%", "C: 2%","D: 3%"]
             ]
phone5 = ["Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi A bendidir!"]

question6 =  [
             "6. 1000 manatliq SUAL : Yerin tebii peyki nedir?",
             "6. 1000 manatliq SUAL : Azerbaycanin en yuksek zirvesi?",
             "6. 1000 manatliq SUAL : Dunyanin en boyuk adasi hansidir?",
             "6. 1000 manatliq SUAL : Ilk kosmosa gonderilen canli nedir?",
             "6. 1000 manatliq SUAL : Riperino nece kill almisdir?"
             ]
answers6 = [
            ["A) Gunes","B) Ay","C) Mars","D) Yupiter"], 
            ["A) Bazarduzu","B) Sahdag","C) Babadag","D) Tufan Dagi"],
            ["A) Madaqaskar","B) Man","C) Qrenlandiya","D) Baffin"],
            ["A) Meymun","B) Pisik","C) Fil","D) It"],
            ["A) Kill almamisdir","B) 100kill","C) 50kill","D) 500kill"]
            ]

correct6 = ["B",
            "A",
            "C",
            "D",
            "A"]
amount6 = 1000

audience6 = [
             ["A: 2%", "B: 95%", "C: 2%", "D: 1%"],
             ["A: 95%", "B: 2%", "C: 2%","D: 1%"],
             ["A: 2%", "B: 3%", "C: 95%","D: 0%"],
             ["A: 2%", "B: 13%", "C: 10%","D: 75%"],
             ["A: 92%", "B: 3%", "C: 2%","D: 3%"]
             ]
phone6 = ["Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi A bendidir!"]

question7 = ["7. 2000 manatliq SUAL : All eyes on me albomunun muellifi kimdir?",
             "7. 2000 manatliq SUAL : Caz-mugam janrinin banisi kimdir?",
             "7. 2000 manatliq SUAL : Uzeyir Hacibeyov necenci ilde anadan olmusdur?",
             "7. 2000 manatliq SUAL : Rep janri harada yaranmisdir?",
             "7. 2000 manatliq SUAL : 36 Boys harada yerlesir?"]
answers7 = [["A) Eminem","B) Xbit","C) 2pac","D) Wiz Khalifa"], 
            ["A) Uzeyir Hacibeyov","B) Islam Salamzade","C) Qara Qarayev","D) Vaqif Mustafazade"],
            ["A) 1906","B) 1899","C) 1885","D) 1882"],
            ["A) Afrika","B) Amerika","C) Azerbaycan","D) Italiya"],
            ["A) Berlin","B) Baki","C) Ehmedli","D) Ankara"]
            ]
correct7 = ["C",
            "D",
            "C",
            "B",
            "A"]
amount7 = 2000
audience7 = [
             ["A: 2%", "B: 2%", "C: 95%", "D: 1%"],
             ["A: 1%", "B: 2%", "C: 2%","D: 95%"],
             ["A: 2%", "B: 3%", "C: 95%","D: 0%"],
             ["A: 2%", "B: 75%", "C: 10%","D: 13%"],
             ["A: 92%", "B: 3%", "C: 2%","D: 3%"]
             ]
phone7 = ["Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi C bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi A bendidir!"]

question8 = ["8. 4000 manatliq SUAL : Texnologiyada neyin yaranmasi    inqilab sayiliır ?",
             "8. 4000 manatliq SUAL : Apple sirketinin yaradicisi kimdir?",
             "8. 4000 manatliq SUAL : Azerbaycanda ilk dovlet universiteti hansidir?",
             "8. 4000 manatliq SUAL : Texnologiya sozunun menasi nedir?",
             "8. 4000 manatliq SUAL : Qeyri-selis mentiq anlayisi kim terefinden ireli surulmusdur?",]
answers8 = [
            ["A) Internet","B) Is emeyi","C) Telefon","D) Monitor"], 
            ["A) Manuel Blum","B) Jorge Affellay","C) Damien Flut","D) Steve Jobs"],
            ["A) WCU","B) BDU","C) ADNSU","D) ADPU"],
            ["A) El-oyunu","B) Teymur-elm","C) Senet-dahisi","D) Bacariq-elm"],
            ["A) Ulvi Memmedov","B) Abraham Linkoln","C) Lutfi Zade","D) Charles Babbage"]
           ]
correct8 = ["A",
            "D",
            "B",
            "D",
            "C"]
amount8 = 4000
audience8 = [
             ["A: 95%", "B: 2%", "C: 2%", "D: 1%"],
             ["A: 1%", "B: 2%", "C: 2%","D: 95%"],
             ["A: 2%", "B: 95%", "C: 3%","D: 0%"],
             ["A: 2%", "B: 13%", "C: 10%","D: 75%"],
             ["A: 2%", "B: 3%", "C: 92%","D: 3%"]
             ]
phone8 = [
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi B bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi C bendidir!"
          ]

question9 = [
             "9. 8000 manatliq SUAL: Dunyada Cinden sonra en cox ehalisi olan olke hansidir?",
             "9. 8000 manatliq SUAL: Ashagidakilerden hansi el arasinda ev almaq qeder vacib sayilir?",
             "9. 8000 manatliq SUAL: Hansi deste ile satilir?",
             "9. 8000 manatliq SUAL: Cavus rutbesinin qolundaki ishare hansi herf formasindadir?",
             "9. 8000 manatliq SUAL: Filmlerde romantik yemek sehnelerinde adeten hansi musiqi aleti calinir?"
             ]

answers9 = [
            ["A) Hindistan", "B) Rusiya", "C) A.B.S", "D) Yaponiya"],
            ["A) Torpaq sahesi", "B) Menzere", "C) Avtomobil", "D) Qonsu"],
            ["A) Kahi", "B) Kok", "C) Kelem", "D) Kesnis"],
            ["A) V", "B) P", "C) C", "D) L"],
            ["A) Kamanca", "B) Qanun", "C) Skripka", "D) Nagara"]
           ]
correct9 = ["A",
            "D",
            "D",
            "A",
            "C"]
amount9 = 8000
audience9 = [
             ["A: 48%", "B: 38%", "C: 14%", "D: 0%"],
             ["A: 0%", "B: 38%", "C: 14%", "D: 48%"],
             ["A: 0%", "B: 38%", "C: 14%", "D: 48%"],
             ["A: 48%", "B: 38%", "C: 14%", "D: 0%"],
             ["A: 14%", "B: 38%", "C: 48%", "D: 0%"]
             ]
phone9 = [
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi D bendidir!",
          "Mence bu sualin cavabi A bendidir!",
          "Mence bu sualin cavabi C bendidir!"
          ]

question10 = [
             "10. 16.000 manatliq SUAL: Bu eserlerden hansi Nizami Gencevinin 'Xemse'-sine daxil deyil?",
             "10. 16.000 manatliq SUAL: Qulunc bedenin hansi hissesinde yaranan bir agridir?",
             "10. 16.000 manatliq SUAL: King Kong filminin qehremani King Kong sevdiyi qadini qaciraraq hansi qulleye qalxir?",
             "10. 16.000 manatliq SUAL: Cizgi filmlerde qehremanlar sablon olaraq ellerinde ne oldugu halda ucmaga baslayirlar?",
             "10. 16.000 manatliq SUAL: Hansi neqliyyat vasitesinde surucu ile danisilmamasini xahis eden bir xeberdarliq yazisi olur?"
             ]
answers10 = [["A) Leyli ve Mecnun", "B) Yeddi Gozel", "C) Abbas ve Gulzer", "D) Sirler Xezinesi"],
             ["A) Bas", "B) Bilek", "C) Ciyin", "D) Diz"],
             ["A) Empire State", "B) Petronas Qulleleri", "C) Eyfel Qullesi", "D) Big Ben"],
             ["A) Zindan", "B) Cetir", "C) Xizek", "D) Sar"],
             ["A) Avtobus", "B) Teyyare", "C) Qatar", "D) Gemi"]]
correct10 = ["C",
             "C",
             "A",
             "D",
             "A"]
amount10 = 16000
audience10 = [
              ["A: 15%", "B: 8%", "C: 77%", "D: 0%"],
              ["A: 15%", "B: 8%", "C: 77%", "D: 0%"],
              ["A: 77%", "B: 8%", "C: 15%", "D: 0%"],
              ["A: 15%", "B: 8%", "C: 0%", "D: 77%"],
              ["A: 77%", "B: 8%", "C: 15%", "D: 0%"]
             ]
phone10 = ["Mence bu sualin cavabi C bendidir!",
           "Mence bu sualin cavabi C bendidir!",
           "Mence bu sualin cavabi A bendidir!",
           "Mence bu sualin cavabi D bendidir!",
           "Mence bu sualin cavabi A bendidir!"]

question11 = [
             "11. 32.000 manatliq SUAL: Ekvator xettini iki defe kesen cay hansidir?",
             "11. 32.000 manatliq SUAL: Insanlarda olan normaldan daha uzun ve one dogru cixmis disler hansi heyvana benzedilir",
             "11. 32.000 manatliq SUAL: Mehemmed Fuzulinin texellusu ne olub?",
             "11. 32.000 manatliq SUAL: Hansi paltar utulenende bir xett olmasina diqqet edilmelidir?",
             "11. 32.000 manatliq SUAL: Velosiped suren meymunlar,od dairesinden tullanan sirler gorursunuzse siz hardasiniz?"
             ]
answers11 = [["A) Kur", "B) Araz", "C) Kango", "D) Nil"],
             ["A) At", "B) Dovsan", "C) Sir", "D) Suiti"],
             ["A) Bakili", "B) Qeddafi", "C) Fuzuli", "D) Qudsi"],
             ["A) Etek", "B) Salvar", "C) Pencek", "D) Koynek"],
             ["A) Sirk", "B) Poliqon", "C) Hipodrom", "D) Lunapark"]]
correct11 = ["C",
             "B",
             "C",
             "B",
             "A"]
amount11 = 32000
audience11 = [["A: 17%", "B: 39%", "C: 42%", "D: 2%"],
              ["A: 17%", "B: 42%", "C: 39%", "D: 2%"],
              ["A: 17%", "B: 39%", "C: 42%", "D: 2%"],
              ["A: 17%", "B: 42%", "C: 39%", "D: 2%"],
              ["A: 42%", "B: 17%", "C: 39%", "D: 2%"]]
phone11 = ["Mence bu sualin cavabi C bendidir!",
           "Mence bu sualin cavabi B bendidir!",
           "Mence bu sualin cavabi C bendidir!",
           "Mence bu sualin cavabi B bendidir!",
           "Mence bu sualin cavabi A bendidir!"]

question12 = [
             "12. 64.000 manatliq SUAL: Uzeyir Hacibeyov harada anadan olmusdur?",
             "12. 64.000 manatliq SUAL: Futbolda sahe xetlerinin icerisinde adeten nece adam olur?",
             "12. 64.000 manatliq SUAL: Hansi meyvenin bereket getirdiyi deyilir?",
             "12. 64.000 manatliq SUAL: Oyun hesabi sorusulan zaman hansi sual verilir?",
             "12. 64.000 manatliq SUAL: Hansi idmanla mesgul olanlarin elastik olduqlari deyilir?"
             ]
answers12 = [["A) Baki", "B) Gence", "C) Agcabedi", "D) Naxcivan"],
             ["A) 26", "B) 23", "C) 22", "D) 28"],
             ["A) Tut", "B) Gilas", "C) Erik", "D) Nar"],
             ["A) Ne?", "B) Kim-Kim?", "C) Neler neler?", "D) Nece nece?"],
             ["A) Gimnastika", "B) Atletika", "C) Gules", "D) Daha dirmasma"]]
correct12 = ["C",
             "B",
             "D",
             "D",
             "A"]
amount12 = 64000
audience12 = [["A: 19%", "B: 26%", "C: 28%", "D: 27%"],
              ["A: 19%", "B: 28%", "C: 26%", "D: 27%"],
              ["A: 19%", "B: 26%", "C: 27%", "D: 28%"],
              ["A: 19%", "B: 26%", "C: 27%", "D: 28%"],
              ["A: 28%", "B: 26%", "C: 19%", "D: 27%"]]

phone12 = ["Cox teessuf ki, bu sualin cavabini bilmirem!",
           "Cox teessuf ki, bu sualin cavabini bilmirem!",
           "Cox teessuf ki, bu sualin cavabini bilmirem!",
           "Cox teessuf ki, bu sualin cavabini bilmirem!",
           "Cox teessuf ki, bu sualin cavabini bilmirem!"]

question13 = [
             "13. 125.000 manatliq SUAL: Tarixde bokscular usyani hansi olkede bas verib?",
             "13. 125.000 manatliq SUAL: Tarzani boyuden heyvan hansidir?",
             "13. 125.000 manatliq SUAL: Sevgililerin bir-birine hediyye vererken dedikleri soz hansidir?",
             "13. 125.000 manatliq SUAL: Cayini demlediyinize yuxusuzluga komek eden ve yazin xebercisi olan cicek hansidir?",
             "13. 125.000 manatliq SUAL: Turkiyenin 'internet olke domeni' hansidir?"
             ]
answers13 = [
             ["A) Cin", "B) Azerbaycan", "C) Rusiya", "D) Amerika"],
             ["A) Qartal", "B) Tulku", "C) Qorilla", "D) Ayi"],
             ["A) Bundan yaxshisi,can sagligi", "B) Xeyrini gor", "C) Yolun aciq olsun", "D) Daha yaxshilarina layiqsen"],
             ["A) Cobanyastigi", "B) Lale", "C) Benovshe", "D) Nergiz"],
             ["A) TK", "B) TL", "C) TC", "D) TR"]
            ]

correct13 = ["A",
             "C",
             "D",
             "A",
             "D"]

amount13 = 125000

audience13 = [
              ["A: 38%", "B: 26%", "C: 21%", "D: 15%"],
              ["A: 21%", "B: 26%", "C: 38%", "D: 15%"],
              ["A: 15%", "B: 26%", "C: 21%", "D: 38%"],
              ["A: 38%", "B: 26%", "C: 21%", "D: 15%"],
              ["A: 15%", "B: 26%", "C: 21%", "D: 38%"]
             ]

phone13 = ["Cox teessuf ki,bu sualin cavabini bilmirem!",
           "Cox teessuf ki,bu sualin cavabini bilmirem!",
           "Cox teessuf ki,bu sualin cavabini bilmirem!",
           "Cox teessuf ki,bu sualin cavabini bilmirem!",
           "Cox teessuf ki,bu sualin cavabini bilmirem!"]

question14 = [
             "14. 500.000 manatliq SUAL: Sahmat oyununda hec - hece qalma nece adlanir?",
             "14. 500.000 manatliq SUAL: Sekerin karamelize edilmesi ile elde edilen,yemeklerde salatlarda istifade olunan sous hansi meyveden hazirlanir?",
             "14. 500.000 manatliq SUAL: Pomidor sousu,qiyme ve uzerine pendir elave edilerek qat qat xemirden hazirlanmish Italyan yemeyi hansidir?",
             "14. 500.000 manatliq SUAL: Durna teli Koroglu Dastaninin necenci qoludur?",
             "14. 500.000 manatliq SUAL: Su icdikde yaxud da nefesi tutduqda kececeyi deyilen,hava udulmasi ile yaranan sese ne deyilir?"
             ]
answers14 = [["A) Lat", "B) Mat", "C) Dat", "D) Pat"],
             ["A) Saftali", "B) Nar", "C) Portagal", "D) Xurma"],
             ["A) Taco", "B) Noodle", "C) Risotto", "D) Lazanya"],
             ["A) 8-ci", "B) 7-ci", "C) 5-ci", "D) 6-ci"],
             ["A) Hicqiriq", "B) Oskurek", "C) Asqirmaq", "D) Qulaq cingiltisi"]]
correct14 = ["D",
             "B",
             "D",
             "A",
             "A"]
amount14 = 500000
audience14 = [["A: 9%", "B: 31%", "C: 11%", "D: 49%"],
              ["A: 9%", "B: 49%", "C: 11%", "D: 31%"],
              ["A: 9%", "B: 31%", "C: 11%", "D: 49%"],
              ["A: 49%", "B: 31%", "C: 11%", "D: 9%"],
              ["A: 49%", "B: 31%", "C: 11%", "D: 9%"]]
phone14 = ["Mence bu sualin cavabi B bendi ola bilmez.C ve ya D bendi daha uygundur!",
           "Mence bu sualin cavabi C bendi ola bilmez.B ve ya A bendi daha uygundur!",
           "Mence bu sualin cavabi B bendi ola bilmez.C ve ya A bendi daha uygundur!",
           "Mence bu sualin cavabi B bendi ola bilmez.A ve ya D bendi daha uygundur!",
           "Mence bu sualin cavabi B bendi ola bilmez.A ve ya C bendi daha uygundur!"]


question15 = [
             "15. Final suali 1.000.000 manatliq SUAL: STEP IT necenci ilde qurulub?",
             "15. Final suali 1.000.000 manatliq SUAL: STEP IT-nin ayliq odenisi ne qederdir?",
             "15. Final suali 1.000.000 manatliq SUAL: Hal-hazirda yazdigimiz proyekt hansi dildedir?",
             "15. Final suali 1.000.000 manatliq SUAL: 1.000.000 manati neyniyeceksen?",
             "15. Final suali 1.000.000 manatliq SUAL: Ele bele sualdi duzgun cavabi A bendidir?"
             ]
answers15 = [["A) 1995", "B) 1999", "C) 2000", "D) 2015"],
             ["A) 300", "B) 400", "C) 2000", "D) 5000"],
             ["A) Python", "B) C++", "C) Java", "D) C#"],
             ["A) Yiyecem", "B) Ish quracam", "C) Istirahet", "D) Banka qoyacam"],
             ["A) Bunu sec", "B) Bunu secme", "C) Bunu da secme", "D) Baxda gor neynirsen"]]
correct15 = ["B",
             "B",
             "A",
             "C",
             "A"]
amount15 = 1000000
audience15 = [["A: 29%", "B: 32%", "C: 28%", "D: 11%"],
              ["A: 29%", "B: 32%", "C: 28%", "D: 11%"],
              ["A: 32%", "B: 29%", "C: 28%", "D: 11%"],
              ["A: 29%", "B: 28%", "C: 32%", "D: 11%"],
              ["A: 32%", "B: 29%", "C: 28%", "D: 11%"]]
phone15 = ["Bu haqqda hec bir melumatim yoxdur!",
           "Bu haqqda hec bir melumatim yoxdur!",
           "Bu haqqda hec bir melumatim yoxdur!",
           "Bu haqqda hec bir melumatim yoxdur!",
           "Bu haqqda hec bir melumatim yoxdur!"]

names = ["Namiq","Eli","Behruz","Huseyn","Rustam","Serxan","Nigar","Yusif","Togrul","Shamil","Malik"]
continue_q = True
number = random.randint(0,4)
money = 0
jokers = ["A.50/50","B.Dosta Zeng","C.Auditoriya"]
check_money = 0

def add_joker(): 
    global jokers
    jokers.append("D.Iki cavab")


def correct_answer(amount):
    global money
    global check_money
    print("\n                 Sizin cavabiniz")
    sleep(2)
    print(f"\n                 DOGRUDUR!,Siz {amount} manat deyerindeki suali dogru cavabladiniz!")
    check_money = amount
    print(f"\n                 Qazandiginiz mebleg : {check_money} manat")
def false_answer(money):
    global continue_q
    continue_q = False
    print("\n                 Sizin cavabiniz yalnisdir!")
    sleep(1)
    print("\n                 Oyun bitdi!")
    print(f"\n                 Qazandiginiz mebleg : {money} manat")

def joker_a(correct,amount):
    global number
    answers = ["A","B","C","D"]
    joker_answers = [correct[number]]
    answers.remove(correct[number])
    number1 = random.randint(0,2)
    joker_answers.append(answers[number1]) 
    joker_answers.sort()
    print(f"\nQalan cavablar : {joker_answers[0]} ve {joker_answers[1]}")
    user_answer = input("\nCavabinizi daxil edin : ")
    if user_answer.upper() == correct[number]:
       correct_answer(amount)
    else :
       false_answer(amount)
def joker_b(phone,correct,amount):
    global names
    global number

    print(f"\n{random.choice(names)} : {phone[number]}")
    user_answer = input("\nCavabinizi daxil edin : ")
    if user_answer.upper() == correct[number]:
       correct_answer(amount)
    else :
       false_answer(amount)

def joker_c(audience,correct,amount):
    global number
    for i in audience[number]:
        print(i)
    user_answer = input("\nCavabinizi daxil edin : ")
    if user_answer.upper() == correct[number]:
       correct_answer(amount)
    else :
       false_answer(amount)
def joker_d(correct,amount):
    global number
    print("\n                 'Iki cavab' jokerinde siz iki cavab sece bilersiniz!\n\n                Eger birinci daxil etdiyiniz cavab duzgun olsa,ikinci secim ekrana chixmayacaq.\n\n                 Eger birinci daxil etdiyiniz cavab sehv olsa ikinci secim ekrana chixacaq. ")
    global jokers
    user_answer = input("\nCavabinizi daxil edin : ")
    if user_answer.upper() == correct[number] :
       correct_answer(amount) 
    elif user_answer.upper() != correct[number] :
         print("\nSizin daxil etdiyiniz cavab yalnishdir!")
         user_answer = input("\nIkinci cavabinizi daxil edin : ")
         if user_answer.upper() == correct[number]:
            correct_answer(amount)
         else :
            false_answer(money)

def use_joker(correct,amount,audience,phone):
    global number
    global chance
    global jokers
    global money
    if len(jokers) == 0 :
       print("Sizin joker haqqlariniz bitib!")
       user_answer = input("Cavabinizi daxil edin : ")
       if user_answer == correct[number] :
          correct_answer(amount)
       else :
          false_answer(money)
    else:
        print("\nSizin jokerleriniz bunlardir!\n")
        for i in jokers:
            print(i)
        joker_answer = input("\nHansi jokerden istifade etmek isteyirsiniz?:")
        if joker_answer.upper() == "A":
           joker_a(correct,amount)
           jokers.remove("A.50/50")
        elif joker_answer.upper() == "B":
            joker_b(phone,correct,amount)
            jokers.remove("B.Dosta Zeng")
        elif joker_answer.upper() == "C":
            joker_c(audience,correct,amount)
            jokers.remove("C.Auditoriya")
        elif joker_answer.upper() == "D":
            joker_d(correct,amount)
            jokers.remove("D.Iki cavab")

            
def print_question(question,answers,correct,amount,audience,phone):
    global number
    global continue_q
    global money
    global chance
    global check_money
    print(question[number])
    sleep(1)
    for i in answers[number]:
        print(i)
    user_answer = input("\nCavabinizi daxil edin(A-D, Joker ucun J daxil edin) : ")
    if user_answer.upper() == correct[number]:
       correct_answer(amount)
    elif user_answer.upper() == "J":
        use_joker(correct,amount,audience,phone)
    else :
        false_answer(money)

print(f"             \n\n                 MILYONER YARISMASINA XOS GELMISINIZ!\n\n             ")
name = input("Adinizi daxil edin : ")
sleep(1)
print(f"\nSalam,{name.capitalize()}")
sleep(1)
print("\n                 Oyunumuzda sertler olduqca sadedir!")
sleep(1)
print("\n                 Oyunda 3 JOKER haqqin olacaq!")
sleep(1)
print("\n                 15 sual var,Her sualda yalniz 1 JOKER istifade ede bilersen!")
sleep(1)
print("\n                 7 ci suala duzgun cavab versen,jokerlerine yeni 'Iki cavab' jokeri elave olunacaq!")
sleep(1)
print("\n                 5ci ve 10cu sualda sene davam etmek ve ya oyundan ayrilmaq secimi teklif olunacaq!")
sleep(1)
print("\n                 Eger oyundan ayrilmagi secsen hemin sualdaki pul meblegini goturub oyundan ayrilacaqsan!")
sleep(1)
print("\n                 Eger qalmagi secsen sene suallar verilmeye davam edilecek!")
sleep(1)
start = input("\nEger hazirsansa baslayaq! (Y/N) :")
if start.upper() == "Y" :
    os.system('cls')
    print(f"\n                 BASLADIQ !! UGURLAR {name.capitalize()} !!!")
    sleep(2)
    if continue_q :
        sleep(3)
        os.system('cls')
        print_question(question1,answers1,correct1,amount1,audience1,phone1)
    if continue_q :
        sleep(3)
        os.system('cls')
        print_question(question2,answers2,correct2,amount2,audience2,phone2)
    if continue_q :
        sleep(3)
        os.system('cls')
        print_question(question3,answers3,correct3,amount3,audience3,phone3)
    if continue_q :
        sleep(3)
        os.system('cls')
        print_question(question4,answers4,correct4,amount4,audience4,phone4)
    if continue_q :
        sleep(3)
        os.system('cls')
        print_question(question5,answers5,correct5,amount5,audience5,phone5)
        money = check_money
        print(" ")
        sleep(3)
        os.system('cls')
        sleep(1)
        print(f"                 {name.capitalize()} , artiq 5 - ci suali cavabladin ! 6 ci suala kecmezden once sene bir teklifimiz var!")
        sleep(1)
        print(" ")
        sleep(1)
        sechim = input("\n                 Eger istesen 500 manati goturub oyundan ayrila bilersen,istemesen oyuna davam ede bilerik.\n\n                 Unutma ki,bir de bu teklifi 10 cu sualda edeceyik!\n\nOyundan ayrilmaq isteyirsen?(Y/N) : ")
        if sechim.upper() == "N":
            if continue_q :
                sleep(3)
                os.system('cls')
                print_question(question6,answers6,correct6,amount6,audience6,phone6)
            if continue_q :
                sleep(3)
                os.system('cls')
                print("                 Eger bu suala duzgun cavab verseniz sizin jokerlerinize yeni 'Iki cavab' jokeri elave olunacaq!\n\n")
                sleep(1)
                print_question(question7,answers7,correct7,amount7,audience7,phone7)
            if continue_q :
                add_joker()
                sleep(3)
                os.system('cls')
                print(f"                {name.capitalize()},'Iki cavab' jokeri elave olundu.Istediyiniz zaman istifade ede bilersiniz!\n\n")
                print_question(question8,answers8,correct8,amount8,audience8,phone8)
            if continue_q :
                sleep(3)
                os.system('cls')
                print_question(question9,answers9,correct9,amount9,audience9,phone9)
            if continue_q :
                sleep(3)
                os.system('cls')
                print_question(question10,answers10,correct10,amount10,audience10,phone10)
                money = check_money
                print(" ")
                sleep(3)
                os.system('cls')
                print(f"                 {name.capitalize()} , artiq 10 cu suali cavabladin ! 11 ci suala kecmezden once sene bir teklifimiz var!")
                sleep(1)
                print(" ")
                sleep(1)
                sechim = input("\n\n                 Eger istesen 16000 manati goturub oyundan ayrila bilersen,istemesen oyuna davam ede bilerik.\n\nOyundan ayrilmaq isteyirsen?(Y/N) : ")
                if sechim.upper() == "N":
                    if continue_q :
                        sleep(3)
                        os.system('cls')
                        print_question(question11,answers11,correct11,amount11,audience11,phone11)
                    if continue_q :
                        sleep(3)
                        os.system('cls')
                        print_question(question12,answers12,correct12,amount12,audience12,phone12)
                    if continue_q :
                        sleep(3)
                        os.system('cls')
                        print_question(question13,answers13,correct13,amount13,audience13,phone13)
                    if continue_q :
                        sleep(3)
                        os.system('cls')
                        print_question(question14,answers14,correct14,amount14,audience14,phone14)
                    if continue_q :
                        sleep(3)
                        os.system('cls')
                        print_question(question15,answers15,correct15,amount15,audience15,phone15)
                elif sechim.upper() == "Y":
                    sleep(3)
                    os.system('cls')
                    sleep(1)
                    print(f"                 Qatildigin ucun tesekkurler,{name.capitalize()}")
                    print(f"                 Qazandigin mebleg : {money} manat")
        elif sechim.upper() == "Y":
            sleep(3)
            os.system('cls')
            sleep(1)
            print(f"                 Qatildigin ucun tesekkurler,{name.capitalize()}")
            print(f"                 Qazandigin mebleg : {money} manat")
            

elif start.upper() == "N":
    print(f"\nTesekkur edirik,{name.capitalize()}")
