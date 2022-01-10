# This project is under heavy development at the moment and is not ready for use

The Client class is the public actor for usage

The 4 REST actions should be generic and not specific
- The exception here is Profile does not get pluralized

Rest Actions should be defined per model type to avoid instances of invalid action usage

Need to check for superboost on a selected campaign and if so, change default options to the superboost values

Need to make sure to rate limit per token

Need to validate token on instantiation

Index results contain up to 3 additional first-level payloads versus ID results

The links payload needs followed to generate the whole collection

Links can generate as http versus https and need fixed before expanding

For indexes, lastsync for that index needs cached for the lifetime of the client along with the data returned (to avoid issues where the return data is no longer available but the lastsync is)

All IEntity types require a Campaign ID to use Actions against

Use Humanizer to pluralize the object names for use in functions (Profile exception)
