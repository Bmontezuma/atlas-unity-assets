# ***Custom Asset Management:***
## ***Unity Editor Tool Crafting***

![image](https://i.imgur.com/IwQkBho.jpg)

***0. Initialize Project***

Fortunately, you will be beginning your journey into Unity Editor customization with a little help.

To set up your project, follow these steps:

Create a new Unity (***2021.3.x***) project
Import this custom UnityPackage file
The 4500 Fantasy Icons Unity asset
Push your project to a new Github repository, unity-assets.
By doing so, you ensure that you start off with all the resources you need and keep track of your project’s version history from the get-go.

It is an essiential requirement not to upload content you do not own to Github. Therefore, we need to be careful that we aren’t adding our 4500 Fantasy Icons content to our Github. We can do this by importing the package into a custom file path and the adding that file path to our [.gitignore](https://github.com/Bmontezuma/atlas-unity/blob/main/unity-assets/.gitignore).

Please store the 4500 Fantasy icons pacakge in a “***CustomAssets” folder like so: Assets/CustomAssets/4000_Fantasy_Icons/***

Throughout your project you will be creating Editor windows. In this example you can see two different versions of the database window, one for weapons that is updated with graphics and one work-in-progress database for armor. Please note you are not required to recreate the visual example, you should create your own implementation and focus on functionality over polish.

![image](https://i.imgur.com/dTTyezN.png)

***1. Craft Editor Menus***

Let’s expand the “Item Database” Editor menu!

First, create three new scripts that inherit from ItemDatabase like so.

public class [ArmorDatabase](https://github.com/Bmontezuma/atlas-unity-assets/blob/main/Assets/Editor/ArmorDatabase.cs) : ItemDatabase<Armor>
public class [PotionDatabase](https://github.com/Bmontezuma/atlas-unity-assets/blob/main/Assets/Editor/PotionDatabase.cs) : ItemDatabase<Potion>
public class [WeaponDatabase](https://github.com/Bmontezuma/atlas-unity-assets/blob/main/Assets/Editor/WeaponDatabase.cs) : ItemDatabase<Weapon>
Then add Buttons to the DatabasesManager window to open the three kinds of item databases.

Here is an example of what we will eventually be building towards for the Database menus:
![image](https://i.imgur.com/jCm8wbK.png)

***2. Forge Weapon System***

Create a new class called WeaponCreation that extends BaseItemCreation. This window will be responsible for creating new Weapon assets within the Editor

Scriptable Object Management:

New weapon assets should be stored in the project under Assets/Items/Weapons.

Pop-up Creation Window:

Add a button to your Weapon Database to open up the Weapon Creation window.

Weapon Properties:

All the properties of a given Weapon item should be assignable in the creation window.

Also, make sure you handle common mistakes / errors such as creating a weapon with a name that is already taken. There are lots of edge cases to cover!

Your creation window may look something like this:
![image](https://i.imgur.com/UTJLiLI.png)

***3. Weapon Annihilation***

Item Selection:

Implement a system to select weapons (via a Mouse Click) within your Weapon Database list.

Item Deletion:

Then, add a button to your Weapon Database called “Delete” that will delete the selected weapon asset.

Confirm to Delete:

However, before we directly delete the asset, have a pop-up menu prompting the user to confirm the action.
![image](https://i.imgur.com/Opj8K2Y.png)

***4. Sculpt Weapon Modifications***

Add a dedicated section to your Weapon Database for editing properties. This section will allow users to modify the properties of the selected weapon.

This section should be robust, supporting modification for all attributes of a weapon. It should also include real-time validation and user feedback mechanisms. The overall goal is to enhance workflow efficiency by allowing developers to create, delete, categorize, and access custom items without leaving the Editor.

Properties Editor Interface:

Develop a user-friendly GUI within Unity’s Editor that lists all weapon properties (see the below list of properties for reference). The interface should allow for straightforward modification of any selected weapon’s attributes.

Real-Time Validation:

Implement field validations to ensure the integrity of the data. This should happen in real-time as the user is entering information. Please look for the following invalid data:

Item names that include special characters (except spaces, dashes, and single quotes)
Empty, null, or default values for any property
Duplicate item names
Feedback Mechanisms:

If a user makes an invalid edit, prompt them through one of the following ways:

A pop-up dialog detailing the error.
Highlighting the invalid field with red or orange.
Automatically rectifying the value (e.g., appending a unique identifier to a duplicate name).
![image](https://i.imgur.com/t3Fcbg0.png)

***5. Armor Assembly***

Now it is time to extend our work to other item types. You will be creating a new class called ArmorCreation that extends BaseItemCreation. The Editor window for this class will facilitate the creation, modification, and deletion of Armor assets within the Unity Editor.

As you will find, the implementation will be quite similar to your Weapon database and creation scripts. The biggest change will be adding the Armor specific properties and removing the Weapon specific properties.

Armor Creation & Deletion:

Implement functionalities for creating new Armor assets, which should be stored under Assets/Items/Armor. Implement a system to select armor items from your Armor Database list and a “Delete” button to remove them after a user confirmation prompt.

Armor Editing:

Implement a feature to edit existing armor assets.

Armor Validation

Add real-time validation for armor properties, similar to the weapon system.

Repo:

GitHub repository: atlas-unity-assets

***6. Potion Crafting***

Last, but not least, potions! Creating a new class called PotionCreation that extends BaseItemCreation.The Editor window for this class will facilitate the creation, modification, and deletion of Potion assets within the Unity Editor.

Potion Creation & Deletion:

Implement functionalities for creating new potion assets, which should be stored under Assets/Items/Potions. Implement a system to select potion items from your Potion Database list and a “Delete” button to remove them after a user confirmation prompt.

Potion Editing:

Implement a feature to edit existing potion assets.

Potion Validation:

Add real-time validation for potion properties.

Repo:

GitHub repository: atlas-unity-assets

***7. Analyze with Statistics***

Extend your Custom Item Database System to include a dedicated page that displays statistics about the different types of items in the database. The page will help developers get insights into the makeup of their items, from the total count of each type to more detailed metrics, like average attributes for weapons, armor, and potions.

Total Count Metrics:

Show the total number of items in the database, as well as the total number for each item type (weapons, armors, potions).

Attribute Averages:

Calculate and display the average attributes for each type of item, like average attack power for weapons or average defense for armor.

Data Grouping:

Provide statistics based on specific attributes like Rarity, ItemType etc.

Most Common Items:

Identify the most commonly used items or attributes within each category.

Item Efficiency:

Calculate a derived metric like weapon efficiency (attack power/base value) and show this data.

Graphical Elements:

Implement bar graphs or pie charts to visualize some of the statistics for a better understanding.

Steps to follow

1. Initialize the Statistics Page

Create a new script named StatisticsPage.cs that inherits from EditorWindow.

Initialize the page with sections for General Item Statistics, Weapon Statistics, Armor Statistics, and Potion Statistics.

2. Implement Total Count Metrics

Use the FindAssetsByType<T>() method to count the number of items for each type.

Display these counts on the statistics page.

3. Calculate Average Attributes

Iterate through each type of item to calculate average attributes.

Display these averages in the respective sections.

4. Data Grouping by Attributes

Group items by specific attributes like Rarity or ItemType and display the count for each group.

5. Identify Most Common Items

Identify and display the most common item or attribute within each category.

6. Calculate Derived Metrics

Implement a method to calculate derived metrics like item efficiency.

Display these metrics on the statistics page.

7. Graphical Elements

Use simple graphical elements bar graphs or pie charts to represent the statistics.

8. User Interactions

Implement foldout sections to allow users to show or hide different types of statistics.

Here are some examples of a work-in-progress statistics page:
![image](https://i.imgur.com/6pNSf0Z.png)

***8. Search and Retrieve***
mandatory
Implement a search functionality within your Weapon Database to find specific items based on their properties or categories. This will enhance user experience by providing a quick and efficient way to access required items without having to scroll through the entire list.

This feature should be both flexible and robust, allowing users to search using different criteria like item name, category, attributes, etc. It should also provide users with real-time results as they type.

Search Interface:

Develop a search bar at the top of the GUI within Unity’s Editor. This search bar should allow for real-time searching and autofill suggestions based on the items present in the database.

Search Filters:

Include filters that can be applied to narrow down the search results. Filters can be for categories like ‘Melee’, ‘Ranged’, ‘Magical’, etc., or for attributes like ‘Damage’, ‘Speed’, etc.

Real-Time Results:

As the user types into the search bar or applies filters, the list of items should automatically update to reflect the search criteria.

Feedback Mechanisms:

If no items match the search criteria:

Display a message stating “No items match your search criteria.”
Option to reset the search and filters.
Repo:

GitHub repository: atlas-unity-assets

***9. Apply Filters***

Implement filtering options to allow users to sort and view items based on specific criteria. The feature should be designed to work seamlessly within the Unity Editor and enhance the overall user experience.

Filter Interface: Develop a user-friendly interface within Unity’s Editor that provides multiple dropdown menus or toggle buttons for the different filtering options.

Filter Categories: Allow users to sort items by different attributes like ‘Name’, ‘Category’, ‘Rarity’, etc.

Real-Time Application: Filters should apply in real-time, updating the list of items as soon as a filter is applied or removed.

Multiple Filters: Enable the application of multiple filters simultaneously.

Reset Option: Provide a ‘Reset Filters’ button that will remove all active filters and restore the original item list.

Here are some examples of filtering in a Weapon database:
![image](https://i.imgur.com/sty83e8.png)

***10. Tally Item Count***

Implement a feature that displays the total count of items based on the current search or filter results. The count should be updated in real-time as filters or search queries are applied or removed.

Display Location:

Add a section within your Item Databases, preferably near the search and filter options, that shows the total item count based on the current view.

Real-Time Update:

The item count should update automatically whenever a search query is applied, changed, or removed, as well as when filters are applied or removed.

User Interface:

The display of the item count should be clear and easily visible, making it a seamless part of the Unity Editor interface.

Repo:

GitHub repository: atlas-unity-assets

***11. Pagination***

Implement a pagination system to display items in a series of pages within your Item Database window. This feature will allow users to better manage and navigate a large set of items without overwhelming the interface.

Page Controls:

Add navigation controls that allow the user to move to the next, previous, first, and last pages.

Items Per Page: Implement an option for the user to choose how many items should be displayed on each page.

Dynamic Update:

The pagination should update dynamically based on search or filter results, as well as the “Items Per Page” selection.

Repo:

GitHub repository: atlas-unity-assets

***12. Import Mastery***

Unity’s Editor provides developers with the capability to interact with external files to bolster the extensibility of projects. Leverage this potential by enabling the ‘Custom Item Database System’ to import data from external files, such as CSV or JSON.

Reading Files: Design a feature within your Editor tool to read data from CSV.

File Selection: Add user-friendly interfaces where developers can choose which external file they wish to import.

Data Conversion: Upon successful import, the data should seamlessly integrate with your ‘Custom Item Database System’, allowing developers to manage these newly imported items as they would with any other item in the system.

Here is some sample data for you to use when building and testing your import functionality. Note you will need to download the Google Sheet as a “CSV” file.

Armor
Weapons
Potions
It is not graded for this task, but you can take this task further by compensating for edge cases and improving the UX in the following ways:

Implement error handling for scenarios such as corrupt files or unsupported file formats.
Ensure that data integrity is maintained upon import. This might involve data validation checks.
Real-time feedback mechanisms to inform the user about the import status or any potential issues.
Repo:

GitHub repository: atlas-unity-assets

***13. Export Wizardry***

In modern software development, the ability to interoperate and share data across platforms and tools is crucial. For the ‘Custom Item Database System’, this translates to the necessity of exporting data in a universally accepted format like CSV.

Writing a file: Create a dedicated feature within your Editor tool that allows for the export of item data (by item type) to a CSV file.

Functional systems: Ensure that the exported CSV maintains the integrity of the data.

User validation: Add a feedback mechanism that informs the user once the export is successful or if any issues arise during the process.

Repo:

GitHub repository: atlas-unity-assets

***14. Aesthetic Refinement***

Your task is to enhance the visual design and usability of various editor windows within the Unity Editor, focusing on improving layout, color schemes, iconography, and overall user interface elements. The windows to be refined include those for different kinds of items (weapons, armor, potions), the base database menu, and the statistics page.

Layout Optimization:

Optimize the layout of the editor windows to maximize space and improve readability.

Color Schemes:

Choose color schemes that are pleasing to the eye and improve the user experience.

Iconography:

Implement intuitive and aesthetically pleasing icons for various actions and categories.

User-Friendly Interfaces:

The design should be intuitive and easy to navigate, with all elements logically arranged.

Feedback Iteration:

Make iterative improvements based on user feedback to ensure the design meets user expectations and creates an engaging experience.

Repo:

GitHub repository: atlas-unity-assets

***15. Chronicle Documentation***

Your task is to create a comprehensive documentation for the project. This should include detailed explanations for each feature implemented, code snippets where necessary, diagrams for architecture, and instructions for set-up and use. The aim is to produce documentation that would help both developers and non-technical stakeholders understand the project in detail.

Feature Explanations:

Provide clear and detailed explanations for each feature implemented in the project.

Code Snippets:

Include relevant code snippets to help elucidate the implemented features.

Architecture Diagrams:

Create diagrams to visually represent the project’s architecture and flow.

Setup and Usage Instructions:

Offer a step-by-step guide on how to set up and use the project.

Repo:

GitHub repository: atlas-unity-assets

***16. Bundle and Distribute***

The final task involves bundling all the features, functionalities, and assets of your editor menu into a Unity Package. The primary aim is to make the entire project easily distributable and installable for other developers.

Package Creation:

Bundle all necessary files, including scripts, assets, and documentation, into a single Unity Package.

Installation Guide:

Provide a brief guide detailing how to install the Unity Package, including any dependencies that may be required.

Repo:

GitHub repository: atlas-unity-assets# ***Unity - Custom Asset Management***
