**Clase Entity**

	Molde del que heredan otras clases pensada para objetos que tienen una posicion en x en y.
	tiene los campos x e y protected para definir las cordenadas en pantalla, un constructor donde se 
	inicializan x e y. Tambien posee abstracto llamado Draw para que las clases que heredan de esta declaren el metodo draw
	dentro de su propia clase.


**Clase Chip**

	representa las fichas del parchis y cada instancia 
	tiene dos campos que son posicion en x y posicion en y (heredadadas de Entity) 
	con sus geter X e Y para no modificar x e y desde fuera de la clase.
	Tambien tiene otro campo que se llama color que corresponde al color de la ficha.
	y un metodo para dibujar la ficha en la pantalla.
	El constructor es heredado y en el se inicializa los campos x e y y se le asigna un color a la ficha.

**Clase Player**
	
	representa el jugador el cual posee un array de *Chips* una variable para almacenar su color
	y un constructor en el cual se inicializa la posicion inicial de las fichas que tiene segun 
	su color en la zona correspondiente del tablero y un metodo para dibujar todas sus fichas en la pantalla


	
