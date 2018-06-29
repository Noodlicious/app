# Noodilicious

## _Table of Contents_
#### 1. Vision
#### 2. Scope In/out
#### 3. MVP
#### 4. Stretch Goals
#### 5. Functional Requirements
#### 6. Non-Functional Requirements
#### 7. Data Flow
#### 8. Wireframe
---

## 1. Vision
Today packaged noodle options are overwhelming.  We want to combat choice paralysis.  Noodlicious aims to guide consumers to the packaged noodle choices best suited to their tastes.  Additionally, we aim to provide suggestions to curious _noodlers_.  No packaged noodles will be left behind.

---
## 2. Scope
_**In**_  
For the curious _noodler_, **Noodlicious** provides a list of packaged noodle options.  The _noodler_ can either see all choices, or they can choose to view a list of choices based on search criteria that they have selected.  There search criteria is based on options that includes: the name of the packaged noodle, the country of origin, the manufacturer and the flavor profile.

For the experienced _noodler_, who have traversed the range of options, they can leave a review for a particular packaged noodle.  Doing so will add to the database of reviews that will benefit the curious _noodlers_.  If they are not happy with the review they had written, they can update it or completely delete it.

_**Out**_ 

Noodlicious cannot provide medical advice.

---

## 3. MVP
A database will be created for the API.  The front end will consume this database.  Additionally, the front end can 
query the API database.  Front end users will have the capability to create, read, update and delete reviews they have entered.

Upon visiting the home page, the user will see the Noodle Finder Search.  The search bar has a drop down menu with the following default values: "sort by: rating", "flavor: all", "country: all."  Below this search bar is a preview of a list of noodles that have been reviewed.

When the user selects a noodle review to read, they will see an image of the product, the brand of the packaged noodle, the country it's from, the flavor, and the user score. Within this area is an option to "Add a Review".  Below this will be the various reviews from other users that will include their comments. A thumbs up or thumbs down next to their comment to describe their sentiments about the packaged noodle.

Should the user feel inclined to leave a review for the product they are looking at, they can click the "Add a Review" button and navigate to a form where they can type in their reviews as well as select a thumbs up or thumbs down to describe how they feel about the product.  For this to be stored in our database, they need to click the submit button under the form.

For _noodlers_ who notice any mistakes about a packaged noodle, they can navigate to the "Edit Noodle Information" page.  From here, they can update information about the product like: the name, brand, country of origin, flavor and description.  Again, for the changes to be registered in our database, the user needs to click the submit button.

---
## 4. Stretch Goals
Include analytics based on the words that users have typed.  Provide analytics based noodle recommendations.  Look into either Parallax or MS Cognitive Services.

Use captcha to check if the user is a human.

Add user login with a password check, so they can only update or delete their reviews and not other reviews.  They can upvote or downvote other reviews or products, like a Reddit for noodles.  Add comment capabilities where they can leave comments on other reviews.  Link the user to their Gmail or Facebook account.

Include pictures of the packaged noodle nutritional information and pictures of the product.  

Navigate the user to a store or e-commerce site where they can buy the product they're viewing.

Include staff picks of the week, month, or all time.

Include user picks that were popular that week, month, or all time.

---
## 5. Functional Requirements
- User can search for noodles based on search criteria
- User can add reviews for each kind of noodle
- User can update their reviews
- User can delete reviews

---
## 6. Non-Functional Requirements
- Usability: The features like read, add, update, or delete a review will be pleasant to use.  The user is able to arrive on page without encountering an error.  All pages will have navigation that will easily lead them to other parts of our site like read or update reviews.  It is possible to accomplish any task with a keyboard and mouse.  The program will not activate skynet.

- Data Integrity: Data should be easy to understand.  Data should be recorded as it was observed and at the time it was entered or updated.  Data should be demonstrate who observed and recorded it.  Data should be accurate and free from errors.

---
## 7. Data Flow
![Data Flow Diagram](https://github.com/Noodlicious/app/blob/master/Assets/DataFlow.jpg)

---
## 8. Wireframe

### Home Page

![Home Page](/Assets/NoodliciousWireFrame1.png)

---
### Read a Review

![Read A Review](/Assets/Noodlicious_Detail.png)

---
### Write A Review

![Write A Review](/Assets/Noodlicious_Review.png)

---
### Edit Noodle Information

![Edit Noodle Information](/Assets/Noodlicious_Edit.png)
