using System.Reflection;

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using NUnit.Framework;

using P01_StudentSystem.Data.Models;

[TestFixture]
public class Test_002
{
    [Test]
    public void ValidateStudentAndCourseEntities()
    {
        //Get assembly from the most important model
        var assembly = typeof(Student).Assembly;

        var modelNames = new string[]
        {
            "Student", "Course", "StudentCourse", "Homework", "Resource"
        };

        var types = new Dictionary<string, Type>();
        foreach (string name in modelNames)
        {
            types[name] = GetModelType(assembly, name);
        }

        //Check Student
        AssertPropertyIsOfType(types["Student"], "StudentId", typeof(int));
        AssertPropertyIsOfType(types["Student"], "Name", typeof(string));
        AssertPropertyIsOfType(types["Student"], "PhoneNumber", typeof(string));
        AssertPropertyIsOfType(types["Student"], "RegisteredOn", typeof(DateTime));
        AssertPropertyIsOfType(types["Student"], "Birthday", typeof(DateTime?));

        AssertCollectionIsOfType(types["Student"], "StudentsCourses", GetCollectionType(types["StudentCourse"]));
        AssertCollectionIsOfType(types["Student"], "Homeworks", GetCollectionType(types["Homework"]));

        //Check Course
        AssertPropertyIsOfType(types["Course"], "CourseId", typeof(int));
        AssertPropertyIsOfType(types["Course"], "Name", typeof(string));
        AssertPropertyIsOfType(types["Course"], "Description", typeof(string));
        AssertPropertyIsOfType(types["Course"], "StartDate", typeof(DateTime));
        AssertPropertyIsOfType(types["Course"], "EndDate", typeof(DateTime));
        AssertPropertyIsOfType(types["Course"], "Price", typeof(decimal));

        AssertCollectionIsOfType(types["Course"], "StudentsCourses", GetCollectionType(types["StudentCourse"]));
        AssertCollectionIsOfType(types["Course"], "Resources", GetCollectionType(types["Resource"]));
        AssertCollectionIsOfType(types["Course"], "Homeworks", GetCollectionType(types["Homework"]));
    }

    public static PropertyInfo GetPropertyByName(Type type, string propName)
    {
        var properties = type.GetProperties();

        var firstOrDefault = properties.FirstOrDefault(p => p.Name == propName);
        return firstOrDefault;
    }

    public static void AssertPropertyIsOfType(Type type, string propertyName, Type expectedType)
    {
        var property = GetPropertyByName(type, propertyName);
        Assert.IsNotNull(property, $"{type.Name}.{propertyName} property not found.");

        var errorMessage = string.Format("{0} property is not {1}!", property.Name, expectedType);
        Assert.That(property.PropertyType, Is.EqualTo(expectedType), errorMessage);
    }

    public static void AssertCollectionIsOfType(Type type, string propertyName, Type collectionType)
    {
        var ordersProperty = GetPropertyByName(type, propertyName);

        var errorMessage = string.Format("{0} property does not exist!", propertyName);

        Assert.IsNotNull(ordersProperty, errorMessage);

        Assert.That(collectionType.IsAssignableFrom(ordersProperty.PropertyType));
    }

    public static Type GetModelType(Assembly assembly, string modelName)
    {
        var modelType = assembly.GetTypes()
            .Where(t => t.Name == modelName)
            .FirstOrDefault();

        Assert.IsNotNull(modelType, $"{modelName} model not found!");

        return modelType;
    }

    public static Type GetCollectionType(Type modelType)
    {
        var collectionType = typeof(ICollection<>).MakeGenericType(modelType);
        return collectionType;
    }
}