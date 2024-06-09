# Money Transfer System

This project aims to transfer money between customers' accounts. In line with this purpose, the project also includes the process of adding a new customer, editing customer account information, deleting a customer account. The project was developed following the MVC (Model-View-Controller) pattern.



## What is the MVC (Model-View-Controller) Pattern?

Model–view–controller (usually known as MVC) is a software design pattern commonly used for developing user interfaces that divides the related program logic into three interconnected elements. (Based on Separation of Concerns)

This is done to separate internal representations of information from the ways information is presented to and accepted from the user.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/mvc-process.png" alt="1200px-MVC-Process.svg" style="zoom:25%;"/>

- The **Model** contains only the pure application data, it contains no logic describing how to present the data to a user.
- The **View** presents the model’s data to the user. The view knows how to access the model’s data, but it does not know what this data means or what the user can do to manipulate it.
- The **Controller** exists between the view and the model. It listens to events triggered by the view (or another external source) and executes the appropriate reaction to these events. In most cases, the reaction is to call a method on the model. Since the view and the model are connected through a notification mechanism, the result of this action is then automatically reflected in the view.



## Introduction

When I started this project, I first focused on creating, editing and deleting a customer account. But even before that, I needed to model a customer.



## Customer Operations

### Modelling A Customer

While modeling a customer, I created a Class structure inside the Model folder as per the MVC pattern.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon.png" alt="carbon" style="zoom:50%;" />

Every customer,

- “Id” with an integer value that will be unique,
- “Name” with a total length of 30 characters and a string value that must be entered,
- “Email” valid and mandatory string value ,
- “Money” in float value, which is mandatory to be entered to increase transaction reliability,
- I developed the class so that it would have these knowledge.

I developed the class so that it would have these knowledge.

### Creating A Customer Account

For creating a customer, first of all, I added a Controller named `CustomersController`in the Controller folder as per the MVC pattern. Then I defined an Action named “Create” for the customer creation process. I used **[HttpGet]** and **[HttpPost]** tags for the view that will be reflected to the user and the input we will receive from the user.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon2.png" alt="carbon2" style="zoom:50%;" />

After completing the action definition process, I created a folder named Customers in the Views folder, making sure that it is the same as the Controller name (“CustomersController”) and created a View for the Create aciton I defined.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon3.png" alt="carbon3" style="zoom:50%;" />

### Editing A Customer Account

The same steps I followed to create a customer account, I followed to edit a customer's account information. I used some documentation for simple HTML codes.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon4.png" alt="carbon4" style="zoom:50%;" />

Unlike the View construct of the Create action, I used razor notation for each customer information in the View I created for the Edit action I defined using the HTML documentation I examined.

Example:

````````
<div class="form-group">
     <label for="Name">Name</label>
     <input type="text" class="form-control" asp-for="Name" value="@Model.Name" />
</div>
````````



<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon5.png" alt="carbon5" style="zoom:50%;" />

### Creating Simulation of The Customer Database 

Instead of testing my work with the static test data I created, I developed a Model that generates the number of fake data I specified using the **“Bogus”** plugin. I created the `CustomerDb`Class in the “Models” folder using the MVC pattern like the way I follow when modelling a customer.   

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon6.png" alt="carbon5" style="zoom:50%;" />



When creating the fake data, I used the documentation <a href="https://wildermuth.com/2023/01/29/generating-sample-data-with-bogus/" target="_blank">here</a> and added the rules that the customer's “Email” information should contain the name information and the “Money” information should be between 100,000-500,000.

### Deleting A Customer Account

For the deletion of the customer account, I defined an Action called **Delete** in the Controls named `CustomersController`. I made arrangements to delete the account of the relevant customer from the database each time it is called.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon7.png" alt="carbon7" style="zoom:50%;" />

After completing the deletion process, I used the`return RedirectToAction(“Index”);`statement at the end of the Action to return the site back to the Index page which I will mention about it.

## Money Transferring Operations

First of all, I created a class named TransferModel in the Models folder to model the transfer process. Then, I added the information of the customer who sends the money, the information of the customer who receives the money and how much money will be sent in the money transfer to be found in this model. I used labels for the rules that the parameters I added are mandatory and “Amount” is greater than 0.

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon8.png" alt="carbon8" style="zoom:50%;" />

Thirdly, I defined the Transfer Action to transfer money in the CustomersController. While doing this, I checked whether the customer to send the money and the customer Ids to receive the money in the TransferModel are present in the customer list; I also checked whether the value of the money to be sent is greater than the value of the money in the customer's account.  

<img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon9.png" alt="carbon9" style="zoom:50%;" />

Finally, I developed the view required for the customer to perform money transfer transactions in the `Transfer`View I created in the Views folder.

<table border="0">
 <tr>
    <td><img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon10.png" alt="carbon10" style="zoom:50%;" /></td>
    <td><img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/transfer-money.png" alt="transfer-money" /></td>
 </tr>
</table>
## Index Page and Starting Project



### Index Page



I created an Index page where the customer can see the entire customer list and manage account additions, edits and deletions, as well as transfer money. While creating this page, I used razor notation to ensure that the information for each of the fake customers created with the Bogus plugin appears in the same format. 
<table border="0">
 <tr>
    <td><img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/carbon11.png" alt="carbon10" style="zoom:50%;" /></td>
    <td><img src="https://raw.githubusercontent.com/EmirhannSahinn/Money-Transfer-System/main/items/customer-list.png" alt="transfer-money" /></td>
 </tr>
</table>


### Money Transfer System Starting and Error Messages

You can access the screen recording I made about the project startup and error messages from the video [here](https://youtu.be/cN0PbWHESI4).
