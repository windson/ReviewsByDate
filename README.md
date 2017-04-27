# Reviews By Date using HDInsight Streaming MapReduce using C#

This repository deals with retrieving number of reviews in the descending order for date.
The reviews are present in dataset reviews.csv and its meta is present in metadata.csv

## Datasets
The meta of files in the dataset is as follows

In reviews.csv, each line contains comma-separated values in the following order:
- User_Id:
- Product_Id:
- User_Name:
- Up_votes: Total number of up-votes given to the review
- Overall_votes: Total votes including up-votes and down-votes given to the review
- Review_Text: Review written by the user
- Rating: Rating given to the product by the user
- Summary: Title given to the review by the user
- Unix_Review_Time: Time at which review was written in UNIX time format
- Review_Date: Date on which review was submitted

In metadata.csv, each line contains comma-separated values in the following order:
- Product_Id: Id of the product
- Title: Name of the product
- Price: Price of product in US dollars
- imUrl: url for the product image
- Sales_Rank:
- Brand:
- Category: Category of the product

## Setup

Spinup the HDInsight Cluster on Azure You can check for reference <a href="https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-provision-linux-clusters" target="_blank">here</a>. I have created this cluster on Linux VM. Choose Azure Storage as Default Storage.

Compile and build the solutions ReviewsMapper.sln and ReviewsReducer.sln (in either release or debug mode but I prefer release mode for production purposes).

Now upload ReviewsMapper.exe and ReviewsReducer.exe to the default azure storage location configured with HDInsight using the Server Explorer. Also upload Reviews.csv file to directory of your choice. For time being I upload it to /reviews/input/Reviews.csv
For beginners follow this <a href="https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-upload-data" target="_blank">link</a> to upload files to HDInsight which provides various interfaces to upload data to an HDInsight cluster.

## Commands
yarn jar /usr/hdp/current/hadoop-mapreduce-client/hadoop-streaming.jar -files wasbs:///ReviewsMapper.exe,wasbs:///ReviewsReducer.exe -mapper ReviewsMapper.exe -reducer ReviewsReducer.exe -input /reviews/input/reviews.csv -output /reviews/output

### Details of Command
The command sends various arguemnts to hadoop-streaming.jar file with yarn as interface that processes the map reduce streaming job.

-files takes map and reduce executables indicating there location on wasbs (Windows Azure Storage Blob).

-mapper with the name of the executable of mapper process. 

-reducer takes the name of the executable of reducer process.

-input is the location of the data to be processed.

-output is the desired location to store the processed data. This needs to be a fresh location every time we run the map reduce process.

After running the command the output folder will contain a text file named part-00000

## Output

Each review in reviews.csv is accompanied by the date on which it was submitted. We need to create the MapReduce methods that count the number of times a review was submitted for a specific date. Then output the result in descending count value.
For reference purpose I've attached the processed part-00000 file in output directory of this repository.
The output file will look like this

01-9-2007	287

10-2-2013	182

12-28-2012	156

01-3-2007	155

.
.
.
