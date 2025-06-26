using System;

#nullable enable

// KoreElementOperations: Utility class to factor out all of the element searching and management operations, and avoid cluttering the platform class

public static class KoreElementOps
{
    public static KoreEntityElement? CreatePlatformElement(string platName, string elemName, string platElemType)
    {
        KoreEntityElement? newElem = null;

        KoreEntity? entity = KoreSimFactory.Instance.EntityManager.EntityForName(platName);
        if (entity == null)
            return newElem;

        if (entity.DoesElementExist(elemName))
            return newElem;

        switch(platElemType)
        {

            default:
                break;
        }

        if (newElem != null)
            entity.AddElement(newElem);

        return newElem;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Element Access Operations
    // ---------------------------------------------------------------------------------------------

    // public static KoreElement? ElementForName(KoreEntity entity, string elemname)
    // {
    //     foreach (var element in entity.Elements)
    //     {
    //         if (element.Name == elemname)
    //             return element;
    //     }
    //     return null;
    // }

    // public static bool DoesElementExist(KoreEntity entity, string elemname)
    // {
    //     foreach (var element in entity.Elements)
    //     {
    //         if (element.Name == elemname)
    //             return true;
    //     }
    //     return false;
    // }

    // public static void DeleteElement(KoreEntity entity, string elemname)
    // {
    //     foreach (var element in entity.Elements)
    //     {
    //         if (element.Name == elemname)
    //         {
    //             platform.Elements.Remove(element);
    //             return;
    //         }
    //     }
    // }

}