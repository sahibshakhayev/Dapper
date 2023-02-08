using Lesson1;

AuthorRepository authorRepository = new AuthorRepository();

//Author author = new Author() { FirstName = "Jahid", LastName="Huseynli"};
//authorRepository.Add(author);
//Console.WriteLine(author);


//authorRepository.AddAuthors(new[]
//{
//new Author{FirstName = "Ashot", LastName= "Qriqoryan"},
//new Author{FirstName = "Jack", LastName= "Nelson"},
//new Author{FirstName = "Salam", LastName= "Salamzadeh"}




//});




// Console.WriteLine(authorRepository.GetById(20));

//authorRepository.Remove(21);


//authorRepository.RemoveAuthors(new int[] { 20, 21 });


//var author = authorRepository.GetById(22);

//if (author != null)
//{
//    authorRepository.Update(new Author { Id = author.Id, FirstName = "Antonio", LastName = "Qirmizi Geymisen" });
//}





var authors = new Author[] {
new Author{Id= 23, FirstName = "Ashot", LastName= "Mehle"},
new Author{Id=24, FirstName = "Jack", LastName= "Salmon"},
new Author{Id=25, FirstName = "Sabir", LastName= "Djabarov"}


};


authorRepository.UpdateAuthors(authors);

//var authors = authorRepository.GetAll().ToList();

//foreach (var author in authors)
//{
//    Console.WriteLine(author);
//}
