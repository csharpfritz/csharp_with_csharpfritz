# Session 1208: Insert, Update, and Delete

Our collection website has grown and now has some interesting features to allow us to maintain the website, but how do we maintain the data?  Let's look at adding, updating, and deleting items in our collection.  Once we have these data maintenance features, we can add Security to them next time. 

## Agenda

1. Let's introduce an "Add New" button to the home page.  This will lead to a page with an empty form to add a new collection item.  Let's not wire up the form to anything YET.
1. We'll want to be able to edit items as well, let's add an edit link to the item display.  We'll use the Open Iconic pencil icon:  

    ```html
    <span class="oi oi-pencil" title="pencil" aria-hidden="true"></span>
    ```

1. We can also add a delete button using the X icon:

    ```html
    <span class="oi oi-x" title="x" aria-hidden="true"></span>
    ```

1. Let's see how Visual Studio 2022 provides a scaffolder to generate these actions for us and inspect the code generated.

1. We need some unit tests and we'll want to connect the new Add, Update, and Delete actions to our Repository object instead of directly using the Entity Framework context.
