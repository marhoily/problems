Programmer expects that the following code fragments will replace every element in the list. Will the code compile? If so, will it throw exceptions? If no, what will be the result?

  // Fragment 1: list with numbers
  foreach (int item in list)
    item = counter++;

  // Fragment 2: list with references
  foreach (object item in list)
    item = new object();
