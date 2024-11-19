Questo entity system funziona secondo questa architettura concettuale:

1. EntityManager
2. EntityComponent
3. EntityState
3. EntityComponentsManager
4. EntityInputSystem*
5. DemGInputSystem*

Questo framework vuole essere un metodo replicabile per creare e gestire le entità di gioco: giocatore, nemici, spawnabili, oggetti interattivi, oggetti raccoglibili, etc..

Ogni entità è composto dagli script sopra elencati, quelli con * indicano che sono facoltativi.

Entity Manager è la main reference di un entità ed è composta dall'entity state, e i vari entity components.
Senza l'entity manager l'entità non può esistere.

Esempio:

Entity Manager -> Nemico
        - Enemy State
            Health: 100
            Speed: 30
        - Components
            - Follow player target
            - Attack


WORK FLOW

1. Creare scriptable object
2. Creare state
3. Creare manager