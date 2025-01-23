# Swarm Intelligence

Es un pequeño proyecto que hice hace ya algún tiempo. En este traté de simular como el comportamiento erratico de una hormiga, unido a una mínima 
comunicación entre todo el grupo, resultaba en un comportamiento que podría determinarse como inteligente. Esto es la base de la Swarm Intelligence.
Como a partir de unas instrucciones básicas dadas a cada individuo, se formaban patrones y comportamientos complejos.

## Problema

Basandome en un video que vi de Swarm Intelligence, me propuse programar una pequeña colonia de hormigas (cells), estas debían llevar la comida a casa, 
con el obstaculo de que van ciegas y andan erraticamente (hay un factor atelatorio que hace que de vez en cuando se tuerzan). 

## Resolución

El punto clave es que si alguna de ellas se topa con su objetivo, ya sea que este en modo busqueda y encuentre la comida, o que lleve comida con ella y encuentre la casa, 
en ambos casos dan un "grito" que el resto escucha, de tal forma que todas las que lo oyen se dirigen hacia la hormiga que acaba de gritar, replicando en el proceso
el grito para que así otras que están un poco más lejos puedan dirigirse hacia su objetivo, o que al menos estén mejor encaminadas. De forma que a pesar que una sola no pueda
cumplir el objetivo de alimentar a la colonia, entre todas lo puedan realizar.
