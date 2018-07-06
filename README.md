# Noodlicious App
Got a hankering for instant noodles but feel overwhelmed by which one(s) to try?
Follow the walk through for guidance on how to use Noodlicious.

## Overview
The Noodilicious App is built on .NET Core 2.1 and resides [here](http://noodlicio.us/).
The app provides a user interface for the Noodlicious API.  

The app has its own server and database. Once consuming the Noodlicious API, the server database is populated with the current info. We made the decision not to allow users to directly perform CRUD operations on the API. Instead, a Create Noodle form is provided to demonstrate the functionality, in that the app is capable of interacting with the API. 

Internally to the app, once the database is populated, the user can view the noodles, and perform CRUD operations on the reviews. The user is also able to search the list based on a name string, which will return results for either full or partial input. The user is also able to view a detailed model of the noodles, which provides more information on the noodle type itself.  Additionally, a user-rating like-or-dislike functionality is included, which keeps track of the total thumbs up or thumbs down votes. A user can also see reviews left by others. Reviews are stored in a separate table within the app database, and joined with the specific noodle type when the user moves to the detail view.

There is also a third-party API consumed to provide random fortunes/wisdom quotes whenever the user returns to the home index view, or clicks the "Feeling Lucky" button.

---
## Walk Through

The following section will provide a screenshot walkthrough of how to use Noodlicious.

#### Home Page:

Welcome to Noodlicious!

![Home Page](/Assets/landingPage.png)

Click "Search All Noodles" and let's get started!

#### Search All Noodles:

So many choices!  Where do we begin?!  Why not type in "ramen" and see what we get?

![Search All Noodles](/Assets/search.png)

#### Search Results:

Hmm, Jin Ramen?  What's that?  Click "View Details" and let's find out...

![Search Results](/Assets/searchResults.png)

#### View Details:

There's so much to learn about Jin Ramen:

![View Details](/Assets/viewDetails.png)

If you're familiar with Jin Ramen, feel free to like or dislike the product.

If you're not familiar with Jin Ramen, click the link below the thumbs to read what people are saying about Jin Ramen.

#### View Reviews:

![View Review](/Assets/viewReviews.png)

Since Noodlicious is a full stack application, the reviews can be updated.  Let's update that review:

![Update Review](/Assets/updateReview.png)

You'll then be redirected to a page with all reviews, where you can read reviews left by others:

![View Update](/Assets/viewUpdate.png)

This list of reviews can also be navigated to at all times from the navbar at the top of the page.

#### Create a Noodle:

Don't see a noodle that should be on the Noodlicious app?  Well, feel free to add one to the system.  Let's use every college student's $0.20 favorite, Maruchan, for this example!

![Add a Noodle](/Assets/createNoodleInfo.png)

Let's see if Maruchan has been added.  Click "Search All Noodles" from the top navbar menu and scroll down.  Well, well, well, Maruchan is now on the Noodilicous app!  Yay!

![See New Noodle](/Assets/addedNoodle.png)

#### Vote thumbs up or down:

Click on "View Details" and we can now see all the information we just added for Maruchan:

![Added Noodle Info](/Assets/addedNoodleInfo.png)

If you're in the mood, vote on whether or not you like or dislike Maruchan with the built in voting capabilities of Noodlicious!

---
## Acknowledgements
- The [Noodlicious team](https://github.com/Noodlicious) because all of this was made possible by us: [jaatay](https://github.com/jaatay), [jcqnly](https://github.com/jcqnly), [Steph, Jesse's life partner](https://github.com/IndigoShock) and [Ben](https://github.com/btaylor93).

- Thanks to yerkee.com for the fortune API.

- Thanks to [Luther](https://github.com/LutherMckeiver) for life.
