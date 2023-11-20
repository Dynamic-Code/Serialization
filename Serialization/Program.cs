using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Person
{
    [XmlElement("FullName")]
    public string Name { get; set; }

    [XmlAttribute]
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Serialization
        var person = new Person { Name = "John Doe", Age = 30 };
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        using (TextWriter writer = new StreamWriter("person.xml"))
        {
            serializer.Serialize(writer, person);
        }

        // Deserialization
        using (TextReader reader = new StreamReader("person.xml"))
        {
            var deserializedPerson = (Person)serializer.Deserialize(reader);
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }
    }
}