# Auteurs
+ Anthony Chaillot
+ Louis Daviaud

# Installation

Sous-eclipse (ou autre), ajouter TOUS les fichiers jar (lib/) au build path

# Utilisation

## ASTParser

Executer fr.harkame.hmin306tp4.astparser.main.ASTParserMain.java

## Spoon

Executer fr.harkame.hmin306tp4.spoon.modification.main.SpoonMain.java

## Fonctionnement

Pour ASTParser et Spoon, toutes les fonctionnalités suivantes ont étés developpées, l'utilisation est la même pour les 2 Mains.

Par défault, l'analyse porte sur le projet lui même, pour analyser un projet il suffit de mettre le chemin du code source (src/) dans les mains au lieu de "./src"

## Metriques

Beaucoup plus complète pour ASTParser, on relève quelques métriques :
+ Nombre de classes
+ Nombre de méthodes
+ ... (Voir ASTParserMain)

## Graphe d'appels

Nous recommendons d'utiliser la version Spoon car celle d'AST pose problème pour les appels de méthode dans une même classe, nottament si l'appel n'utilise pas "this".

Affichage l'ensemble des classes internes an projet (en bleu), pour chaque classe on vois la liste des méthodes de cette dernière.
Une flèche relie les méthodes lorsqu'elles s'appellent entre elles. (Dans le sens de la flèche, methode1 -> méthodeB).

## Exemple avec Spoon

Dans ce projet nous avons tester la modification de code avec Spoon.

``` java
package fr.harkame.spoon.modification.model;

public class Person
{
	private int age;

	private String name;

	public Person(int age, String name)
	{
		super();
		this.age = age;
		this.name = name;
	}

	@Override
	public String toString()
	{
		return "Person : " + System.getProperty("line.separator") + 
			"Name : " + name + System.getProperty("line.separator")
			+ "Age : " + age + System.getProperty("line.separator");
	}
}

```

Après modification

``` java

package fr.harkame.spoon.modification.model.modified;

public class Person {
    private java.lang.String city = "";

    private int age;

    private java.lang.String name;

    public Person(int age, java.lang.String name, java.lang.String city) {
        super();
        this.age = age;
        this.name = name;
        this.city = city;;
    }

    @java.lang.Override
    public java.lang.String toString() {
        return "Person : "
        + "city : " + city
        + "age : " + age
        + "name : " + name
        ;
    }

    public void newMethod() {
        System.out.println("New method");
    }
}

```

# Librairie

+ ASTParser
+ [Spoon](http://spoon.gforge.inria.fr)
+ [mxGraph](https://github.com/jgraph/mxgraph) : Pour l'affichage des graphes d'appel/de couplage
