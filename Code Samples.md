- [Home](/README.md)
- [Journal](/journal.md)
- [Timeline](/timeline.md)
- [Proposal](/proposal.md)
- [Bibliography](/bibliography.md)



Week 1 
The two ways we are potentially using to move the player. We have not decided which one we prefer yet. 

* Option 1:

        ...

        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        Debug.Log(horizontal);
        Debug.Log(vertical);

        HandleMovement(horizontal, vertical);
        }

        private void HandleMovement(float h, float v){

            myRigidbody.velocity = new Vector2(h * 90, v * 90);    
        }
        
        ...

* Option 2:

        ...

        private void Update()
        {
            if (Input.GetKey(KeyCode.W)) // Move player up
            {
                transform.Translate(Vector2.up * moveSpeed);
            }

            if (Input.GetKey(KeyCode.A)) // Move player left
            {
                transform.Translate(Vector2.left * moveSpeed);
            }

            if (Input.GetKey(KeyCode.S)) // Move player down
            {
                transform.Translate(Vector2.down * moveSpeed);
            }

            if (Input.GetKey(KeyCode.D)) // Move player right
            {
                transform.Translate(Vector2.right * moveSpeed);
            }
        }

        ...

        
Week 2

add more into getkey for movement and attack


    ...

    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Move the player up
        {
            Debug.Log("w");
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.A)) // Move the player left
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.S)) // Move the player down
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", true);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.D)) // Move the player right
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", true);
        }

        if(Input.GetKey(KeyCode.Space))
        { 
            anim.SetBool("AttackUp", true);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Attack Down");
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", true);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", true);
            anim.SetBool("AttackRight", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", true);
        }

       ...
