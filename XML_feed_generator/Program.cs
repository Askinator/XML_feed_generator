using System.Xml.Linq;
namespace XML_feed_generator;

class ProductFeed
{
	public static void Main()
	{
		XNamespace g = "http://base.google.com/ns/1.0";
		var DocName = "test2";
		XDocument document = new(
			new XDeclaration("1.0", "utf-8", "yes"),
			new XElement("rss",
				new XAttribute("version", "2.0"),
				new XAttribute(XNamespace.Xmlns + "g", g),
				new XElement("channel",
					new XElement("title", "Demo Google product feed"),
					new XElement("link", "https://link_to_feed.com"),
					new XElement("description", "This is a reandomly generated Google product feed with 100 items"),
					CreateElements(100))
				));

		document.Save(DocName + ".xml");

		//System.Console.WriteLine(new Item("1").ToXml());
	}

	private static IEnumerable<XElement> CreateElements(int n)
	{
		List<XElement> list = new();

		for (int i = 1; i < n; i++)
		{
			list.Add(new Item(new Random().Next(10000,99999).ToString()).ToXml());
		}

		return list;
	}
}
//random int
//Random rnd = new();
//int id = rnd.Next(1, 1000000);

class Item : ProductFeed
{
	public string id;
	public string title;
	public string description;
	public string link;
	public string image_link;
	public string availability;
	public string price;
	public string sale_price;
	public string google_product_category;
	public string product_type;
	public string brand;
	public string gtin;
	public string color;
	public string gender;
	public string material;
	public string pattern;
	public string size;
	public static string[] google_product_categories = 
		File.ReadAllLines("GoogleProductCategories.txt").Where(line => line.Contains("Apparel")).ToArray();
	public int length = google_product_categories.Length;

	public Item(string id)
	{
		this.id = id;
		this.title = "item" + id;
		this.description = "This is a short description of the item";
		this.link = "http://demofeeditems.com/itemlink/" + id;
		this.image_link = "http://demofeeditems.com/image/" + id;
		this.availability = "in_stock";
		var priceInt = new Random().Next(10, 200);
		this.price = priceInt + "DKK";
		this.sale_price =  (0.3 * priceInt).ToString();
		this.google_product_category = google_product_categories[new Random().Next(1, length)];
		this.product_type = "Shirts & Tops";
		this.brand = "Brand";
		this.gtin = "1234567890123";
		this.color = "red";
		string[] genOptions = {"Male", "Female", ""};
		this.gender = genOptions[new Random().Next(1, genOptions.Length)];
		this.material = "cotton";
		this.pattern = "striped";
		this.size = "Small/Medium/Large";
	}

	public XElement ToXml()
	{
		XNamespace g = "http://base.google.com/ns/1.0";

		return new XElement("item",
			new XElement(g + "id", this.id),
			new XElement(g + "title", this.title),
			new XElement(g + "description", this.description),
			new XElement(g + "link", this.link),
			new XElement(g + "image_link", this.image_link),
			new XElement(g + "availability", this.availability),
			new XElement(g + "price", this.price),
			new XElement(g + "sale_price", this.sale_price),
			new XElement(g + "google_product_category", this.google_product_category),
			new XElement(g + "product_type", this.product_type),
			new XElement(g + "brand", this.brand),
			new XElement(g + "gtin", this.gtin),
			new XElement(g + "color", this.color),
			new XElement(g + "gender", this.gender),
			new XElement(g + "material", this.material),
			new XElement(g + "pattern", this.pattern),
			new XElement(g + "size", this.size)
			);
	}
}


