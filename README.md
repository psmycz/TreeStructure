# TreeStructure
[![Build Status](https://dev.azure.com/patryk09-90/Struktura%20Drzewiasta/_apis/build/status/psmycz.TreeStructure?branchName=master)](https://dev.azure.com/patryk09-90/Struktura%20Drzewiasta/_build/latest?definitionId=2&branchName=master)

This application is deployed on [Azure](https://tree-structure.azurewebsites.net/). 

Simple application that creates catalog tree structure with working CRUD operations and Web Api. Enabled sorting and moving features. 

- ~/api/category
- ~/api/category/id
- ~/WebApiTree.html

 Założenia co do technologii:

- baza danych MSSQL, PostgreSQL 9.3 / MySql 5.4 lub nowsza,
- ASP.NET MVC (Uwaga nie należy używać gotowej kontrolki),
- HTML 5, CSS

Założenia dotyczące realizacji zadania:

- struktura drzewiasta ma umożliwiać działanie na dowolnej ilości poziomów,
- funkcje jakie mają być dostępne dla administratora: dodawanie, edycja, usuwania, sortowanie (zarówno węzłów jak i liści), przenoszenie węzłów do innych gałęzi,
- powinna być możliwość rozwinięcia całej struktury lub wybranych węzłów,
- powinny zostać zastosowane zabezpieczenia uniemożliwiające wprowadzanie nieprawidłowych danych.
- mile widziane zastosowanie skryptów client-side,
- w bazie danych mile widziane funkcje/procedury składowe

Dane do logowania:

- login: admin
- haslo: Admin1
