<?php 
        
class Website_Visitor { 
    private $idVisitor;
    private  $visited_page; 
    private  $visit_start; 
    private  $visit_end; 
    private $operation_result;
    
    function __construct($idVisitor=null, $visited_page=null, $visit_start=null, $visit_end=null, $operation_result=null) {
        $this->idVisitor = $idVisitor;
        $this->visited_page = $visited_page;
        $this->visit_start = $visit_start;
        $this->visit_end = $visit_end;
        $this->operation_result = $operation_result;
    }

    function setIdVisitor($idVisitor) {
        $this->idVisitor = $idVisitor;
    }

    function setvisited_page($visited_page) {
        $this->visited_page = $visited_page;
    }

    function setVisit_start($visit_start) {
        $this->visit_start = $visit_start;
    }

    function setVisit_end($visit_end) {
        $this->visit_end = $visit_end;
    }

    function setOperation_result($operation_result) {
        $this->operation_result = $operation_result;
    }

        function getOperation_result() {
        return $this->operation_result;
    }

        function getIdVisitor() {
        return $this->idVisitor;
    }

    function getvisited_page() {
        return $this->visited_page;
    }

    function getVisit_start() {
        return $this->visit_start;
    }

    function getVisit_end() {
        return $this->visit_end;
    }

    function visit_start() {
        $this->visit_start=date("Y-m-d H:i:s");
    }
    
    function visit_page() {
        $this->visited_page++;
    }
    
    function end_visit() {
        $this->visit_end=date("Y-m-d H:i:s"); 
    }
    
    function visit_log() {
        return "VISITED PAGES : " . $this->visited_page . "<br> VISIT DURATION : " . $this->visit_start . " - " . $this->visit_end;
    }
    
    //this is the create operation
    function save_session() {
        $this->operation_result=DAL_Website_Visitor::{"save_session"}($this->visited_page,$this->visit_start,$this->visit_end);
        return $this->operation_result;
    }
    
    static function retrieve_visits() {
        $visits = DAL_Website_Visitor::{"retrieve_visits"}();
        return $visits;
    }
    
    function update_visit() {
        $this->operation_result=DAL_Website_Visitor::{"update_visit"}($this->idVisitor,$this->visited_page,$this->visit_start,$this->visit_end);
        return $this->operation_result;
        }
    
    function delete_visit() {
        $this->operation_result=DAL_Website_Visitor::{"delete_visit"}($this->idVisitor);
        return $this->operation_result;
    }
    
   } 
?>
