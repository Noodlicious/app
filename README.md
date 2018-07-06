# Noodlicious App

## Overview
The Noodilicious App is built on .NET Core 2.1 and resides [here](http://noodlicio.us/).
The app provides a user interface for the Noodlicious API.  

The app has its own server and database. Once consuming the Noodlicious API, the server database is populated with the current info. We made the decision not to allow users to directly perform CRUD operations on the API. Instead, a Create Noodle form is provided to demonstrate the functionality, in that the app is capable of interacting with the API. 

Internally to the app, once the database is populated, the user can view the noodles, and perform CRUD operations on the reviews. The user is also able to search the list based on a name string, which will return results for either full or partial input. The user is also able to view a detailed model of the noodles, which provides more information on the noodle type itself, along with a user-rating like-or-dislike function, which keeps track of the total thumbs up or thumbs down votes. A user can also see reviews left by others. Reviews are stored in a separate table within the app database, and joined with the specific noodle type when the user moves to the detail view.

There is also a third-party API consumed to provide random fortunes/wisdom quotes whenever the user returns to the home index view, or clicks the "Feeling Lucky" button.
---
## Walk Through

The following section will provide a screenshot walkthrough of how to use the app.

#### Home Page:

**localhost:yourPortNumber/api/brand** or

**https://noodliciousapi.azurewebsites.net/api/brand**

Click "Try It Out" and then "Execute" in order to see all the brands:

![Get All Brands](/Assets/getBrand.png)

![See All Brands](/Assets/getBrandJSON.png)


#### Noodle List View:

**localhost:yourPortNumber/api/brand/`{id}`**

**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Click "Try It Out":

![Get Brand By ID](/Assets/getBrandByID.png)

Enter in 2, for this example, and then click "Execute":

![Get Brand By ID Type In Id](/Assets/getBrandByIDTypeInId.png)

Use 2 for this example:

![Show Brand By Id](/Assets/getBrandByIDJSON.png)


#### Noodle detail view:

**localhost:yourPortNumber/api/brand** or

**https://noodliciousapi.azurewebsites.net/api/brand**

Click "Try It Out":

![Post New Brand](/Assets/postNewBrand.png)

We'll be using "SamYang", the hottest ramen brand, for this example.
Swagger will display "Id", but we don't need it because the database
will assign it an ID number.  Delete the Id portion when typing
in info for a new brand.

![Post New Brand Example](/Assets/postNewBrandEx.png)

Swagger will show the new entry:

![Post New Brand Response](/Assets/postNewBrandResponse.png)

#### Add a review:

**localhost:yourPortNumber/api/brand/`{id}`**

**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Click "Try It Out":

![Update A Brand](/Assets/updateBrand.png)

Let's update the SamYang example we created earlier.  Type the name in ALL
CAPS and let's say they're a North Korean company.  The ID is needed for this
entry.  We can tell which ID it is from the POST request made in the previous
section:

![Update A Brand Example](/Assets/updateBrandEx.png)

Go back to the "GET a brand by ID" direction to check the update:

![Check Update](/Assets/checkUpdate.png)

The response shows that SamYang has been updated:

![Check Update Works](/Assets/checkUpdateWorks.png)

#### Update a review:

**localhost:yourPortNumber/api/brand/`{id}`**

**https://noodliciousapi.azurewebsites.net/api/brand/{id}**

where id is the id of a brand

Let's delete the SAMYANG entry:

![Delete Brand By Id](/Assets/deleteBrandById.png)

See if it's still there by following the directions for 
"GET all brands" directions:

![Check Delete Work](/Assets/getBrand.png)

SAMYANG is no longer in the list of brands:

![List After Deletion](/Assets/deleteBrandWorks.png)

#### Delete a review:

**localhost:yourPortNumber/api/noodle** or

**https://noodliciousapi.azurewebsites.net/api/noodle**

![Get All Noodle](/Assets/getAllNoodle.png)

Click "Try It Out" and then "Execute" in order to see all the noodles:

![See All Noodle](/Assets/getAllNoodleJSON.png)

#### Vote thumbs up or down:

**localhost:yourPortNumber/api/noodle`{id}`** or

**https://noodliciousapi.azurewebsites.net/api/noodle/{id}**

where id is the id of a brand

Click "Try It Out":

![Get Noodle By Id](/Assets/getNoodleById.png)

Enter 4 for this example and click "Execute":

![Get Noodle By Id With Id](/Assets/getNoodleByIdWithId.png)

The information for brand #4 will be displayed in a JSON format:
![See Noodle Info](/Assets/getNoodleByIdJSON.png)

#### Add a new noodle

**localhost:yourPortNumber/api/noodle** or

**https://noodliciousapi.azurewebsites.net/api/noodle**

Click "Try It Out":

![Post New Brand](/Assets/postNewBrand.png)

We'll be using "Cup of Noodle", a college staple, for this example.
Swagger will display "Id", but we don't need it because the database
will assign it an ID number.  Delete the Id portion when typing
in a info for a new noodle.

![Post New Noodle Example](/Assets/postNoodleEx.png)

See if it's there by following the "GET a noodle by ID" directions:

![Post New Noodle Response](/Assets/ViewAddedNoodle.png)





---
## Acknowledgements
- A **huge** thanks to the [Noodlicious team](https://github.com/Noodlicious): [jaatay](https://github.com/jaatay), [IndigoShock](https://github.com/IndigoShock)
and [btaylor93](https://github.com/btaylor93).

- Thanks to yerkee.com for the fortune API.
