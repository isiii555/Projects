using System.Timers;
using Timer = System.Timers.Timer;
using ConsoleApp15;
using System.Linq;
using System.Text.Json;
using System.Diagnostics;

#region Initialize
Shop shop = new(0,"Avashnoy",5000);
List<Vegetable> tomato = new();
tomato.Capacity = 200;
List<Vegetable> potato = new();
potato.Capacity = 200;
List<Vegetable> cucumber = new();
cucumber.Capacity = 200;
Dictionary<string,double> vnamesbuy = new();
Dictionary<string,double> vnamessale = new();
Queue<Customer> customers = new();
List<string> vnames = new() { "pamidor", "kartof", "xiyar" };
List<string> subnames = new() { "sogan", "badimcan", "biber" };
shop.Stands.Add("pamidor", tomato);
shop.Stands.Add("kartof", potato);
shop.Stands.Add("xiyar", cucumber);
vnamesbuy.Add("pamidor",3);
vnamesbuy.Add("kartof",4);
vnamesbuy.Add("xiyar",5);
vnamessale.Add("pamidor", 4.5);
vnamessale.Add("kartof", 6.2);
vnamessale.Add("xiyar", 6.5);
bool epidemic = false;
int hours = 0;
int days = 0;
int weeks = 0;
int check = 0;
#endregion

Timer tm = new(9000);
tm.Elapsed += Timer_Elapsed1;

#region Functions
void AddCustomer(ref Shop shop,ref Queue<Customer> customers)
{
    Random random = new Random();
    if (shop.currentRaiting <= 3)
    {
        int num = random.Next(1, 4);
        for (int i = 0; i < num; i++)
        {
            customers.Enqueue(new Customer(random.Next(0, 1000), 0));
            shop.customerCount++;
        }
    }
    else if (shop.currentRaiting > 3 && shop.currentRaiting <= 6)
    {
        int num = random.Next(4, 7);
        for (int i = 0; i < num; i++)
        {
            customers.Enqueue(new Customer(random.Next(0, 1000), 0));
            shop.customerCount++;
        }
    }
    else if(shop.currentRaiting > 6)
    {
        int num = random.Next(8, 11);
        for (int i = 0; i < num; i++)
        {
            customers.Enqueue(new Customer(random.Next(0, 1000), 0));
            shop.customerCount++;
        }
    }
}

void TimeElapse(ref int hours, ref int days, ref int weeks,ref int check)
{ 
        if (hours == 24)
        {
            if (days == 6)
            {
                weeks++;
                days = 0;
                check = 2;
            }
            else
            {
                days++;
                hours = 0;
                check = 1;
            }
        }
        else
        {
            hours++;
            check = 0;
        }
}

void BuyVegetable(ref Shop shop,List<Vegetable> vegetables,string vname,Dictionary<string,double> vnamesbuy,Dictionary <string,double> vnamessale)
{
    Random rand = new();
    double price = 0;
    double saleprice = 0;
    int count = 0;
    price = vnamesbuy[vname];
    saleprice = vnamessale[vname];
    int capacity = vegetables.Capacity;
    double money = shop.Bank / shop.Stands.Count;
    while(money >= 0 && (capacity - vegetables.Count) > 0)
    {
        List<int> ehtimal = new() { 0, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
        vegetables.Add(new Vegetable(ehtimal[rand.Next(ehtimal.Count)],price,saleprice));
        money -= price;
        shop.Bank -= price;
        shop.Cost += price;
        count++;
    }
    Console.WriteLine($"Yeni {vname} elave olundu!");
    Console.WriteLine($"Elave olunan {vname} sayi : {count}");
    vegetables = vegetables.OrderByDescending(vt => vt.Status).ToList();
    Console.WriteLine($"{vname} stendi yeniden duzuldu");
    Thread.Sleep(3000);
    shop.employee.CheckShop(ref shop);
}

void CheckStands(ref Shop shop,ref Dictionary<string, double> vnamesbuy,ref Dictionary<string, double> vnamessale)
{
    Console.Clear();
    Console.WriteLine("Stendler yoxlanilir...");
    Thread.Sleep(3000);
    foreach (var item in shop.Stands)
    {
        if(item.Value.Count == 0)
        {
            Console.Clear();
            Console.WriteLine($"{item.Key} stendi boshdur...");
            Console.WriteLine();
            Console.WriteLine($"Menecer {item.Key} almaga getdi...");
            Console.WriteLine();
            Thread.Sleep(3000);
            BuyVegetable(ref shop, item.Value, item.Key, vnamesbuy, vnamessale);
        }
    }
    Console.WriteLine("Yoxlanish bitdi,stendlerde problem yoxdur...");
}
void CustomerBuy(ref Shop shop, ref Queue<Customer> customers,ref List<string> vnames )
{
    Random rand = new();
    var customer = customers.Dequeue();
    List<int> ehtimal = new() { 1, 0, 0, 0,0 };
    double profit = 0;
    bool cond = false;
    while (customer.Money > 0 && ehtimal[rand.Next(ehtimal.Count)] == 0)
    {
        int choice = rand.Next(vnames.Count);
        int count = shop.Stands[vnames[choice]].Count;
        if (count > 0)
        {
            if (shop.Stands[vnames[choice]][count - 1].Status == 0)
            {
                shop.Stands[vnames[choice]].RemoveAt(count - 1);
                Console.WriteLine("Mushteri curuk terevez gordu ve odenish etmeden dukani terk etdi!");
                Console.Write($"Dukanin reytingi : {(float)(shop.currentRaiting)} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" -0.1");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                shop.vegetableCount++;
                shop.currentRaiting -= 0.1;
                customer.Moral = 1;
                Thread.Sleep(3000);
                cond = true;
                break;
            }
            customer.Money -= shop.Stands[vnames[choice]][count - 1].salePrice;
            customer.Moral = 0;
            profit += shop.Stands[vnames[choice]][count - 1].salePrice;
            shop.Stands[vnames[choice]].RemoveAt(count - 1);
            cond = true;
        }
        else
        {
            Console.WriteLine("Mushterinin istediyi terevez qurtardigi ucun dukani terk etdi!");
            Console.Write($"Dukanin reytingi : {(float)(shop.currentRaiting)} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -0.1");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            shop.currentRaiting -= 0.1;
            customer.Moral = 1;
            Thread.Sleep(3000);
            cond = true;
            break;
        }
    }
    if (profit > 0 && cond)
    {
        shop.Profit += profit;
        shop.Bank += profit;
        shop.currentRaiting += 0.05;
        Console.WriteLine("Mushteri alishverish etdi ve dukani terk etdi!");
        Console.Write($"Dukanin banki : {(float)(shop.Bank)}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" +{(float)(profit)}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.Write($"Dukanin reytingi : {(float)(shop.currentRaiting)}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" +0.05");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Thread.Sleep(3000);
    }
    else if(cond)
        Console.WriteLine("Mushteri alishverish etmedi ve dukani terk etdi!");
    Console.WriteLine();
}

void OlderVegetables(ref Shop shop)
{
    foreach (var item in shop.Stands)
    {
        for (int i = 0; i < item.Value.Count; i++)
        {
            if (item.Value[i].Status != 0)
            {
                item.Value[i].Status += -1;
            }
        }
    }
}

void CurrentStatus(ref Shop shop)
{
    Console.Clear();
    Console.WriteLine("-------Heftelik Hesabat-------");
    Console.WriteLine($"Hazirki qiymetlendirme : {shop.currentRaiting}");
    Console.WriteLine($"Mushteri sayi : {shop.customerCount}");
    Console.WriteLine($"Budce : {shop.Bank} $ ");
    Console.WriteLine($"Qazanc : {shop.Profit} ");
    Console.WriteLine($"Xerc : {shop.Cost}");
    Console.WriteLine($"Atilan terevezler : {shop.vegetableCount}");
    Console.WriteLine($"Ishcinin adi : {shop.employee.Name}");
    shop.customerCount = 0;
    shop.Profit = 0;
    shop.Cost = 0;
    shop.vegetableCount = 0;
    Thread.Sleep(3000);
}


void Timer_Elapsed1(object? sender, ElapsedEventArgs e)
{
    TimeElapse(ref hours, ref days, ref weeks, ref check);
}

void Serialize(ref Shop shop)
{

    var options = new JsonSerializerOptions { WriteIndented = true };

    var json = JsonSerializer.Serialize(new Report(shop.currentRaiting,shop.customerCount,shop.Profit,shop.Cost,shop.vegetableCount),options);
    File.WriteAllText("hesabat.json", json);
    File.WriteAllText("hesabat(text).txt", json);
}

void AddVegetableAssorty(ref Shop shop,ref Dictionary<string,double> namesbuy,ref Dictionary<string,double> namessale)
{
    Random rand = new();
    int num = rand.Next(subnames.Count);
    var list = new List<Vegetable>();
    list.Capacity = 200;
    shop.Stands.Add(subnames[num], list);
    vnamesbuy.Add(subnames[num], rand.Next(1, 5));
    vnamessale.Add(subnames[num], rand.Next(6, 9));
    subnames.RemoveAt(num);
}

void Epidemic(ref int weeks,ref bool epidemic,ref Shop shop, ref Dictionary<string, double> namesbuy, ref Dictionary<string, double> namessale)
{
    if (weeks > 1 && weeks % 2 == 0)
    {
        epidemic = true;
        Console.Clear();
        Console.WriteLine("Epidemiya bashladi");
        AddVegetableAssorty(ref shop, ref namesbuy, ref namessale);
        Thread.Sleep(3000);
    }
    else if (weeks > 1 && weeks % 2 != 0 && epidemic)
    {
        epidemic = false;
        Console.Clear();
        Console.WriteLine("Epidemiya bitdi!");
        Thread.Sleep(3000);
    }
}
#endregion

#region Main

while (true)
{
    tm.Start();
    tm.AutoReset = false;
    if((days == 0 && hours == 0 && weeks == 0) || (hours == 12 || hours == 24))
        CheckStands(ref shop, ref vnamesbuy, ref vnamessale);
    if(shop.Bank > 10000)
    {
        foreach (var item in shop.Stands)
        {
            item.Value.Capacity += 200;
        }
    }
    Console.Clear();
    Epidemic(ref weeks, ref epidemic, ref shop, ref vnamesbuy, ref vnamessale);
    if (!epidemic)
    {
        Thread.Sleep(10000);
        Console.Clear();
        Console.WriteLine($"{hours} saat , {days} gun , {weeks} hefte kecdi...\n");
        if (check == 0)
        {
            if (hours == 12 || hours == 24)
                CheckStands(ref shop, ref vnamesbuy, ref vnamessale);
            AddCustomer(ref shop, ref customers);
            if (customers.Count > 0)
            {
                Console.WriteLine("Mushteriler geldi...\n");
                Console.WriteLine($"Mushterilerin sayi : {customers.Count} \n");
                while (customers.Count > 0)
                {
                    CustomerBuy(ref shop, ref customers, ref vnames);
                }
                Thread.Sleep(3000);
            }
        }
        else if (check == 1)
        {
            OlderVegetables(ref shop);
        }
        else if (check == 2)
        {

            OlderVegetables(ref shop);
            Serialize(ref shop);
            CurrentStatus(ref shop);
            shop.currentRaiting += 1;
        }
    }
    else {
        Console.WriteLine($"{hours} saat , {days} gun , {weeks} hefte kecdi...\n");
        Console.WriteLine("Epidemiya yarandigi ucun mushteri gelmedi..");
    }
    tm.Stop();
    Console.Clear();
}

#endregion
