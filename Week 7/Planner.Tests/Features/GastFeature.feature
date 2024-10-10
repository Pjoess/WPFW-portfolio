Feature: Gast
  
  Scenario: GastBestaatNiet
    Given gast Tim bestaat niet
    When gast Tim word verwijdert
    Then komt er een error 404
    