using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using d02_ex00;

string pathToBooks = "./book_reviews.json";
string pathToMovies = "./movie_reviews.json";


if (!File.Exists(pathToBooks) || !File.Exists(pathToMovies))
{
	System.Console.WriteLine("Json file is missing");
	return ;
}
string jsonBook = File.ReadAllText(pathToBooks);
parsed book = JsonSerializer.Deserialize<parsed>(jsonBook);
List<ISearchable> books = new List<ISearchable>();
for (int i = 0; i < book.results.Length; i++)
	books.Add(new Book(book.results[i].book_details[0]["title"], book.results[i].book_details[0]["author"],
	book.results[i].book_details[0]["description"], book.results[i].rank, book.results[i].list_name, book.results[i].amazon_product_url));


string jsonMovie = File.ReadAllText(pathToMovies);
parsed movie = JsonSerializer.Deserialize<parsed>(jsonMovie);
List<ISearchable> movies = new List<ISearchable>();
for (int i = 0; i < movie.results.Length; i++)
	movies.Add(new Movie(movie.results[i].title, movie.results[i].critics_pick,
							movie.results[i].summary_short, movie.results[i].link["url"]));

System.Console.WriteLine("> Input search text:");
string userInput = Console.ReadLine();
if (userInput == null)
	showEverything(books, movies);
else
	find(books, movies, userInput);


static void find(List<ISearchable> books, List<ISearchable> movies, string userInput)
{
	int booksFound = 0;
	int moviesFound = 0;
	foreach (ISearchable found in books)
	{
		if (found.Title.ToUpper().Contains(userInput.ToUpper()) && found.MediaType.Equals("BOOK"))
			booksFound++;
	}
	foreach (ISearchable found in movies)
	{
		if (found.Title.ToUpper().Contains(userInput.ToUpper()) && found.MediaType.Equals("MOVIE"))
			moviesFound++;
	}
	if (booksFound + moviesFound == 0)
		System.Console.WriteLine($"There are no \"{userInput}\" in media today.");
	else
		System.Console.WriteLine($"\nItems found: {booksFound + moviesFound}");
	if (booksFound != 0)
	{
		System.Console.WriteLine($"\nBook search result [{booksFound}]:");
		foreach (ISearchable found in books)
			if (found.Title.ToUpper().Contains(userInput.ToUpper()) && found.MediaType.Equals("BOOK"))
				System.Console.WriteLine(found);
	}
	if (moviesFound != 0)
	{
		System.Console.WriteLine($"\nMovie search result [{moviesFound}]:");
		foreach (ISearchable found in movies)
			if (found.Title.ToUpper().Contains(userInput.ToUpper()) && found.MediaType.Equals("MOVIE"))
				System.Console.WriteLine(found);
	}
}


static void showEverything(List<ISearchable> books, List<ISearchable> movies)
{
	System.Console.WriteLine($"\nItems found: {books.Count + movies.Count}");
	System.Console.WriteLine($"\nBook search result [{books.Count}]:");
	foreach (ISearchable found in books)
		System.Console.WriteLine(found);

	System.Console.WriteLine($"\nMovie search result [{movies.Count}]:");
	foreach (ISearchable found in movies)
		System.Console.WriteLine(found);
}